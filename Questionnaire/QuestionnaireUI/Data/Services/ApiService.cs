using Common.Models.ViewModels;
using System.Text.Json;

namespace QuestionnaireUI.Data.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public ApiService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var output = JsonSerializer.Deserialize<T>(content, _options);

            return output;
        }
    }
}
