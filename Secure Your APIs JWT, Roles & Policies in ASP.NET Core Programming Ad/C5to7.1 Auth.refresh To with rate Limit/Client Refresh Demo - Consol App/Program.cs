using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Security;
using System.Threading.Tasks;

namespace StudentApiConsoleClient
{
    class Program
    {
        // ==========================
        // Configuration Section
        // ==========================
        private const string BaseUrl = "https://localhost:7217/";

        // Use an existing account from your in-memory data store
        // (You said you switched to an admin user)
        private const string Email = "alia.maher@admin.com";
        private const string Password = "admin123";

        // How long we wait between calls to force access token expiry.
        // (Set your API access token expiry to ~10 seconds to see refresh easily.)
        private const int WaitSecondsBeforeSecondCall = 15;

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Student API Console Client (Access + Refresh Tokens) ===");
            Console.WriteLine();

            using var http = CreateHttpClientForLocalDev(BaseUrl);

            // 1) Login to get AccessToken + RefreshToken
            var tokenPair = await LoginAsync(http, Email, Password);

            if (tokenPair == null ||
                string.IsNullOrWhiteSpace(tokenPair.AccessToken) ||
                string.IsNullOrWhiteSpace(tokenPair.RefreshToken))
            {
                Console.WriteLine("Login failed.");
                return;
            }

            // Store tokens in a single mutable object (no ref/out; async-friendly)
            var tokenState = new TokenState(tokenPair.AccessToken, tokenPair.RefreshToken);

           
            Console.WriteLine("Login succeeded.");
            Console.WriteLine("======================================");
            Console.WriteLine("Initial Tokens:");
            Console.WriteLine("======================================");

            Console.WriteLine($"Access Token:\n{tokenState.AccessToken}");
            Console.WriteLine();
            Console.WriteLine($"Refresh Token:\n{tokenState.RefreshToken}");
            Console.WriteLine("======================================");
            Console.WriteLine();
         

            // 2) First secured call (expected 200)
            Console.WriteLine("First call: GET /api/Students/All (expected 200)...");
            await CallGetAllStudentsWithAutoRefreshAsync(http, Email, tokenState);

            // 3) Wait to let access token expire (same run, no restart)
            Console.WriteLine();
            Console.WriteLine($"Waiting {WaitSecondsBeforeSecondCall} seconds to let the access token expire...");
            await Task.Delay(TimeSpan.FromSeconds(WaitSecondsBeforeSecondCall));
            Console.WriteLine("Wait done.");
            Console.WriteLine();

            // 4) Second secured call (expected 401 then refresh then 200)
            Console.WriteLine("Second call: GET /api/Students/All (expected 401 -> refresh -> 200)...");
            await CallGetAllStudentsWithAutoRefreshAsync(http, Email, tokenState);

            Console.WriteLine();
            Console.WriteLine("Done.");
        }

        // ==========================
        // Helper Methods
        // ==========================

        // Creates an HttpClient for local HTTPS development (self-signed dev cert support).
        static HttpClient CreateHttpClientForLocalDev(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslErrors) =>
                        sslErrors == SslPolicyErrors.None ||
                        sslErrors == SslPolicyErrors.RemoteCertificateChainErrors
            };

            return new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // --------------------------
        // Login: returns AccessToken + RefreshToken
        // --------------------------
        static async Task<TokenResponse?> LoginAsync(HttpClient http, string email, string password)
        {
            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };

            var response = await http.PostAsJsonAsync("/api/Auth/login", request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Invalid credentials.");
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Login failed: {response.StatusCode}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<TokenResponse>();
        }

        // --------------------------
        // Refresh: returns NEW AccessToken + NEW RefreshToken (rotation)
        // --------------------------
        static async Task<TokenResponse?> RefreshTokensAsync(HttpClient http, string email, string refreshToken)
        {
            var request = new RefreshRequest
            {
                Email = email,
                RefreshToken = refreshToken
            };

            var response = await http.PostAsJsonAsync("/api/Auth/refresh", request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Refresh failed: Unauthorized (refresh token invalid/expired/revoked).");
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Refresh failed: {response.StatusCode}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<TokenResponse>();
        }

        // --------------------------
        // Sends a request with AccessToken.
        // If 401 happens, refreshes tokens once and retries the request one time.
        // --------------------------
        static async Task<HttpResponseMessage> SendWithAutoRefreshAsync(
            HttpClient http,
            HttpRequestMessage request,
            string email,
            TokenState tokenState)
        {
            // First attempt with current access token
            ApplyBearerToken(request, tokenState.AccessToken);
            var response = await http.SendAsync(request);

            // If not 401, return immediately
            if (response.StatusCode != HttpStatusCode.Unauthorized)
                return response;

            // 401 => access token expired/invalid => try refresh once
            Console.WriteLine("Access token rejected (401). Refreshing tokens...");

            response.Dispose();

            var newTokens = await RefreshTokensAsync(http, email, tokenState.RefreshToken);
            if (newTokens == null ||
                string.IsNullOrWhiteSpace(newTokens.AccessToken) ||
                string.IsNullOrWhiteSpace(newTokens.RefreshToken))
            {
                // Refresh failed => force re-login scenario
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            // Update stored tokens (rotation)
            tokenState.AccessToken = newTokens.AccessToken;
            tokenState.RefreshToken = newTokens.RefreshToken;

            Console.WriteLine("Refresh succeeded. Retrying the original request...");
            Console.WriteLine("======================================");
            Console.WriteLine("NEW TOKENS RECEIVED AFTER REFRESH:");
            Console.WriteLine("======================================");

            Console.WriteLine($"New Access Token:\n{tokenState.AccessToken}");
            Console.WriteLine();
            Console.WriteLine($"New Refresh Token:\n{tokenState.RefreshToken}");

            Console.WriteLine("======================================");
            Console.WriteLine();


            // Retry the original request once with new access token
            using var retryRequest = CloneRequest(request);
            ApplyBearerToken(retryRequest, tokenState.AccessToken);

            return await http.SendAsync(retryRequest);
        }

        // --------------------------
        // Example secured call: GET /api/Students/All
        // Uses auto-refresh helper
        // --------------------------
        static async Task CallGetAllStudentsWithAutoRefreshAsync(
            HttpClient http,
            string email,
            TokenState tokenState)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "api/Students/All");

            var response = await SendWithAutoRefreshAsync(http, request, email, tokenState);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("401 Unauthorized. Access token expired and refresh failed (need re-login).");
                return;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                Console.WriteLine("403 Forbidden. You are authenticated, but not allowed to do this action.");
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Request failed: {response.StatusCode}");
                return;
            }

            var students = await response.Content.ReadFromJsonAsync<List<StudentDto>>();
            if (students == null)
            {
                Console.WriteLine("No data returned.");
                return;
            }

            Console.WriteLine($"{students.Count} students returned:");
            foreach (var s in students)
            {
                Console.WriteLine($"- {s.Name} (Age: {s.Age}, Grade: {s.Grade})");
            }

            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine("Current Token State After Request:");
            Console.WriteLine("======================================");

            Console.WriteLine($"Access Token:\n{tokenState.AccessToken}");
            Console.WriteLine();
            Console.WriteLine($"Refresh Token:\n{tokenState.RefreshToken}");

            Console.WriteLine("======================================");
            Console.WriteLine();

        }

        // --------------------------
        // Token utilities
        // --------------------------
        static void ApplyBearerToken(HttpRequestMessage request, string accessToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        // HttpRequestMessage cannot be re-sent once sent, so we clone it for retry.
        // For GET calls, this is enough. For POST/PUT with body, you'd need to recreate content too.
        static HttpRequestMessage CloneRequest(HttpRequestMessage original)
        {
            var clone = new HttpRequestMessage(original.Method, original.RequestUri);

            foreach (var header in original.Headers)
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

            // Content is not used for GET here, but we copy if present.
            // Note: some HttpContent types are single-use; for robust POST/PUT retries,
            // recreate content from the original payload instead of copying.
            if (original.Content != null)
                clone.Content = original.Content;

            return clone;
        }

        static string Preview(string value, int count)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Length <= count ? value : value.Substring(0, count) + "...";
        }
    }

    // ==========================
    // Token State (mutable, async-safe)
    // ==========================
    class TokenState
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenState(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }

    // ==========================
    // DTOs
    // ==========================
    class LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    class RefreshRequest
    {
        public string Email { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }

    class TokenResponse
    {
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }

    class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public int Grade { get; set; }
    }
}
