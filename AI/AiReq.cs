
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GTL.AI
{
    public class Ollama
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<string> Ai_Request(string prompt)
        {
            var json = JsonSerializer.Serialize(new
            {
                model = "llama3.2",
                prompt = prompt,
                stream = false
            });

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync(
                "http://localhost:11434/api/generate",
                content
            );

            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(result);

            return doc.RootElement
                .GetProperty("response")
                .GetString() ?? "";
        }
    }
}
