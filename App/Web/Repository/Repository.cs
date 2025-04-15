using System.Text;
using System.Text.Json;

namespace Web.Repository
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _options => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAsync<T>(string url, int id)
        {
            await _httpClient.DeleteAsync($"{url}/{id}");
        }

        public async Task<List<T>> GetAllAsync<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<T>>(content, _options);
                return list!;
            }
            return null!;
        }

        public async Task<T> GetAsync<T>(string url, int id)
        {
            var response = await _httpClient.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(content, _options);
                return data!;
            }
            return default!;
        }

        public async Task<T> PostAsync<T>(string url, T entity)
        {
            var content = JsonSerializer.Serialize(entity, _options);
            var d = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, d);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(result, _options);
                return data!;
            }
            return default!;
        }

        public async Task<T> PutAsync<T>(string url, T entity)
        {
            var content = JsonSerializer.Serialize(entity, _options);
            var d = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, d);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(result, _options);
                return data!;
            }
            return default!;
        }
    }
}