using System.Text.Json;

namespace QuestionnaireUI.Data.Helpers
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

        public async Task<TReturn> PostAsync<TInput, TReturn>(string uri, TInput data)
        {
            var response = await _client.PostAsJsonAsync(uri, data);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var output = JsonSerializer.Deserialize<TReturn>(content, _options);

            return output;
        }

        public async Task<TReturn> PutAsync<TInput, TReturn>(string uri, TInput data)
        {
            var response = await _client.PutAsJsonAsync(uri, data);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var output = JsonSerializer.Deserialize<TReturn>(content, _options);

            return output;
        }

        public async Task<TReturn> PatchAsync<TReturn>(string uri)
        {
            var response = await _client.PatchAsync(uri, null);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var output = JsonSerializer.Deserialize<TReturn>(content, _options);

            return output;
        }

        public async Task<TReturn> DeleteAsync<TReturn>(string uri)
        {
            var response = await _client.DeleteAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var output = JsonSerializer.Deserialize<TReturn>(content, _options);

            return output;
        }
    }
}
