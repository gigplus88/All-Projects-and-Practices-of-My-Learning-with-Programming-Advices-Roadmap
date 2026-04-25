using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using System.Security.Claims;




// Create the application builder.
// This object is responsible for configuring services and middleware.
var builder = WebApplication.CreateBuilder(args);


// ===============================
// JWT Authentication Configuration
// ===============================


// Register authentication services in the dependency injection container.
// JwtBearerDefaults.AuthenticationScheme tells ASP.NET Core that
// JWT Bearer authentication will be the default authentication method.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secretKey = builder.Configuration["JwtSettings:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new Exception("JWT Secret Key is missing! Check User Secrets or Environment Variables.");
        }
        // TokenValidationParameters define how incoming JWTs will be validated.
        options.TokenValidationParameters = new TokenValidationParameters
        {

            // Ensures the token was issued by a trusted issuer.
            ValidateIssuer = true,


            // Ensures the token is intended for this API (audience check).
            ValidateAudience = true,


            // Ensures the token has not expired.
            ValidateLifetime = true,


            // Ensures the token signature is valid and was signed by the API.
            ValidateIssuerSigningKey = true,


            // The expected issuer value (must match the issuer used when creating the JWT).
            ValidIssuer = "StudentApi",


            // The expected audience value (must match the audience used when creating the JWT).
            ValidAudience = "StudentApiUsers",

            //Last Stored of secret key
            //Encoding.UTF8.GetBytes("THIS_IS_A_VERY_SECRET_KEY_123456")


            // The secret key used to validate the JWT signature.
            // This must be the same key used when generating the token.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew = TimeSpan.Zero // Optional: Set clock skew to zero to prevent token expiration issues during testing
        };
    });

// ===============================
// Authorization Configuration
// ===============================


// Register authorization services.
// This enables attributes like [Authorize] and role-based authorization.
builder.Services.AddAuthorization();



// Define a custom authorization policy named "StudentOwnerOrAdmin".
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StudentOwnerOrAdmin", policy =>
        policy.Requirements.Add(new StudentOwnerOrAdminRequirement()));
});


// Register the custom authorization handler that enforces the "StudentOwnerOrAdmin" policy.
builder.Services.AddSingleton<IAuthorizationHandler, StudentOwnerOrAdminHandler>();



// Add rate limiting services to protect the API from abuse and ensure fair usage.
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddPolicy("AuthLimiter", httpContext =>
    {
        var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ip,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5, // Allow a maximum of 5 requests
                Window = TimeSpan.FromMinutes(1), // Time window of 1 minute
                QueueLimit = 0 // No queuing, reject immediately when limit is exceeded , without 
            });
    });
});


// Register controller support.
builder.Services.AddControllers();



// ===============================
// Swagger Configuration
// ===============================


// Enables Swagger endpoint discovery.
builder.Services.AddEndpointsApiExplorer();


// Enables Swagger UI for testing and documentation.
// Register Swagger generator and customize its behavior.
builder.Services.AddSwaggerGen(options =>
{
    // ===============================
    // 1) Define the JWT Bearer security scheme
    // ===============================
    //
    // This tells Swagger that our API uses JWT Bearer authentication
    // through the HTTP Authorization header.
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // The name of the HTTP header where the token will be sent.
        Name = "Authorization",


        // Indicates this is an HTTP authentication scheme.
        Type = SecuritySchemeType.Http,


        // Specifies the authentication scheme name.
        // Must be exactly "Bearer" for JWT Bearer tokens.
        Scheme = "Bearer",


        // Optional metadata to describe the token format.
        BearerFormat = "JWT",


        // Specifies that the token is sent in the request header.
        In = ParameterLocation.Header,


        // Text shown in Swagger UI to guide the user.
        Description = "Enter: Bearer {your JWT token}"
    });


    // ===============================
    // 2) Require the Bearer scheme for secured endpoints
    // ===============================
    //
    // This tells Swagger that endpoints protected by [Authorize]
    // require the Bearer token defined above.
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // Reference the previously defined "Bearer" security scheme.
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },


            // No scopes are required for JWT Bearer authentication.
            // This array is empty because JWT does not use OAuth scopes here.
            new string[] {}
        }
    });
});







builder.Services.AddCors(options =>
{
    options.AddPolicy("StudentApiCorsPolicy", policy =>
    {
        policy
            .WithOrigins(
                "https://localhost:7217",
                "http://localhost:5215"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



// Build the application.
// After this point, services are frozen and middleware is configured.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Redirects HTTP requests to HTTPS, ensuring secure communication between the client and server.
app.UseHttpsRedirection();

app.UseCors("StudentApiCorsPolicy");


app.UseRateLimiter();


app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
    {
        await context.Response.WriteAsync("Too many login attempts. Please try again later.");
    }
});

app.UseAuthentication();

app.UseAuthorization();


// ✅ Step 6: Global 403 logging middleware (place it HERE)
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "anonymous";
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var path = context.Request.Path.ToString();


        // ✅ Centralized security log for authorization abuse
        app.Logger.LogWarning(
            "Forbidden access. UserId={UserId}, Path={Path}, IP={IP}",
            userId,
            path,
            ip
        );
    }
});



app.MapControllers();

app.Run();
