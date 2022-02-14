

using Newtonsoft.Json;

namespace downstreem.Services
{
    public class HttpServices<T> : IHttpServices<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
       
        public HttpServices(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<T>> GetAll(string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(body);
            return result;
        }
        public async Task<T> GetbyId(int id, string url)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync(url + "/" + id);
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(body);
            return result;
        }
    }
}
