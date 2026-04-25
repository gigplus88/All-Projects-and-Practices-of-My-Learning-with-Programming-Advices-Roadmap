


using System.Net.Http;
using System.Text;
using System.Text.Json;


class Program
{
    static async Task Main()
    {
        var client = new HttpClient();


        // 🔴 CHANGE THIS PORT to match your API
        var url = "https://localhost:7217/api/Auth/login";


        var payload = new
        {
            email = "test@test.com",
            password = "wrongpassword"
        };


        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");


        Console.WriteLine("Starting login flood test...\n");


        for (int i = 1; i <= 10; i++)
        {
            try
            {
                var response = await client.PostAsync(url, content);


                Console.WriteLine(
                    $"Attempt {i} → Status: {(int)response.StatusCode} ({response.StatusCode})");


                // Recreate content each time (important)
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attempt {i} → ERROR: {ex.Message}");
            }
        }


        Console.WriteLine("\nTest completed :-).");
        Console.ReadLine();
    }
}




