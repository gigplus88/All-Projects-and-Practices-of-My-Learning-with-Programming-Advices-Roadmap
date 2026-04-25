
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentApi.DataSimulation;
using StudentApi.DTOs.Auth;
using StudentApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;




namespace StudentApi.Controllers
{
   

    // This controller is responsible for authentication-related actions,
    // such as logging in and issuing JWT tokens.
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        
        // This endpoint handles user login.
        // It verifies credentials and returns a JWT token if login succeeds.
        [HttpPost("login")]
        [EnableRateLimiting("AuthLimiter")]
        public IActionResult Login([FromBody] LoginRequest request)
        {

            // ✅ Capture caller IP once (used in all logs for tracing)
            // 📌 We store IP as a string and default to "unknown" to avoid null issues.
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // Step 1: Find the student by email from the in-memory data store.
            // Email acts as the unique login identifier.
            var student = StudentDataSimulation.StudentsList
                .FirstOrDefault(s => s.Email == request.Email);


            // If no student is found with the given email,
            // return 401 Unauthorized without revealing which field was wrong.
            if (student == null)
            {
                _logger.LogWarning($"Failed login attempt (email not found). Email={request.Email}, IP={ip}");
                return Unauthorized("Invalid credentials");
            }

            // Step 2: Verify the provided password against the stored hash.
            // BCrypt handles hashing and salt internally.
            bool isValidPassword =
                BCrypt.Net.BCrypt.Verify(request.Password, student.PasswordHash);


            // If the password does not match the stored hash,
            // return 401 Unauthorized.
            if (!isValidPassword)
            {
                _logger.LogWarning($"Failed login attempt (email or password not found). Email={request.Email}, IP={ip}");

                return Unauthorized("Invalid credentials");
            }

            // Step 3: Create claims that represent the authenticated user's identity.
            // These claims will be embedded inside the JWT.
            var claims = new[]
            {
                    // Unique identifier for the student
                    new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),


                    // Student email address
                    new Claim(ClaimTypes.Email, student.Email),


                    // Role (Student or Admin) used later for authorization
                    new Claim(ClaimTypes.Role, student.Role)
            };


            // Step 4: Create the symmetric security key used to sign the JWT.
            // This key must match the key used in JWT validation middleware.
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));


            // Step 5: Define the signing credentials.
            // This specifies the algorithm used to sign the token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);   //Signature


            // Step 6: Create the JWT token.
            // The token includes issuer, audience, claims, expiration, and signature.
            var token = new JwtSecurityToken(
                issuer: "StudentApi",
                audience: "StudentApiUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10), //10 minutes you can use this token
                signingCredentials: creds
            );


            // Step 7: Serialize the JWT into a string.
            // This is what the client will send in the Authorization header.
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            // Step 8: Create refresh token (secure random).
            // Refresh token is used to request a new access token later.
            var refreshToken = GenerateRefreshToken();

            // Step 9: Store refresh token securely (hash + expiry + not revoked).
            // We store the HASH only (never store the raw refresh token).
            student.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            student.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            student.RefreshTokenRevokedAt = null;


            // Success log with user ID, email, and IP for traceability.
            _logger.LogInformation(
                "Successful login. UserId={UserId}, Email={Email}, IP={IP}",
                student.Id,
                student.Email,
                ip
            );


            // Step 10: Return both tokens to the client.
            // AccessToken is used for API calls.
            // RefreshToken is used only for renewing sessions.
            return Ok(new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
        // Generates a cryptographically secure random refresh token.
        // The returned string is safe to send to the client, but should be stored as a hash on the server.
        private static string GenerateRefreshToken()
        {
            var bytes = new byte[64];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }






        //Refresh token endpoint: client sends refresh token, server validates it and issues new access token (and optionally a new refresh token).
        [HttpPost("refresh")]
        [EnableRateLimiting("AuthLimiter")]

        public IActionResult Refresh([FromBody] RefreshRequest request)
        {
            // ✅ Capture caller IP once (used in all logs for tracing)
            // 📌 We store IP as a string and default to "unknown" to avoid null issues.
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";


            var student = StudentDataSimulation.StudentsList
                .FirstOrDefault(s => s.Email == request.Email);

            if (student == null)
            {

                _logger.LogWarning(
                    "Invalid refresh attempt (email not found). Email={Email}, IP={IP}",
                    request.Email,
                    ip
                );

                return Unauthorized("Invalid refresh request");
            }
            if (student.RefreshTokenRevokedAt != null)
                return Unauthorized("Refresh token is revoked");

            if (student.RefreshTokenExpiresAt == null || student.RefreshTokenExpiresAt <= DateTime.UtcNow)
                return Unauthorized("Refresh token expired");

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, student.RefreshTokenHash);
            if (!refreshValid)
                return Unauthorized("Invalid refresh token");

            // Issue NEW access token (same claims & signing settings as login)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.Role, student.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "StudentApi",
                audience: "StudentApiUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Rotation: replace refresh token
            var newRefreshToken = GenerateRefreshToken();
            student.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken);
            student.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            student.RefreshTokenRevokedAt = null;

            return Ok(new TokenResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }


        // Logout endpoint: client sends refresh token, server validates it and marks it as revoked (so it cannot be used again).
        [HttpPost("logout")]
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            var student = StudentDataSimulation.StudentsList
                .FirstOrDefault(s => s.Email == request.Email);

            if (student == null)
                return Ok(); // Do not reveal if user exists

            bool refreshValid = BCrypt.Net.BCrypt.Verify(request.RefreshToken, student.RefreshTokenHash);
            if (!refreshValid)
                return Ok();

            student.RefreshTokenRevokedAt = DateTime.UtcNow; // Mark the refresh token as revoked (so it cannot be used again)
            return Ok("Logged out successfully");
        }


    }
}



