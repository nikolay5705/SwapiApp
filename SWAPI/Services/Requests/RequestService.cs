using System.Text.Json;

namespace SWAPI.Services.Requests
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAsync<T>(string url)
        {
            var jsonOption = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<T>(responseBody, jsonOption);
            return data;
        }
    }
}