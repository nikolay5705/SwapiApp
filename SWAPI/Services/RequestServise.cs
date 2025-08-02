using SWAPI.Interfaces;
using System.Text.Json;
using SWAPI.ApiResponses;
using SWAPI.SwapiModels;

namespace SWAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<ApiResponse<T>> GetAsync<T>(string url)
        {
            var JsonOption = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ApiResponse<T>>(responseBody, JsonOption);
            return data;
        }


    }
}