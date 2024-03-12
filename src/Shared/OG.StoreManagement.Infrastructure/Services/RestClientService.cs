using Microsoft.Extensions.Configuration;
using OG.StoreManagement.Core.Services;
using System.Net.Http.Json;
using static OG.StoreManagement.Core.Consts.HttpClientConsts;

namespace OG.StoreManagement.Infrastructure.Services
{
    public class RestClientService : IRestClientService
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<MicroServices, string> _httpClientDictionary;

        public RestClientService(IConfiguration configuration)
        {
            _configuration = configuration;

            _httpClientDictionary = new()
            {
                { MicroServices.Product, _configuration["ProductAPIUrl"] ?? string.Empty},
                { MicroServices.Order, _configuration["OrderAPIUrl"] ?? string.Empty},
                { MicroServices.Inventory, _configuration["InventoryAPIUrl"] ?? string.Empty},
            };
        }
        public async Task<T> GetAsync<T>(MicroServices microservice, string endpoint)
        {
            _httpClientDictionary.TryGetValue(microservice, out string urlBase);
            HttpClient client = new()
            {
                BaseAddress = new Uri(urlBase)
            };

            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                return default;
            }
        }

        public async Task<T> PostAsync<T, U>(MicroServices microservice, string endpoint, U body)
        {
            _httpClientDictionary.TryGetValue(microservice, out string urlBase);
            HttpClient client = new()
            {
                BaseAddress = new Uri(urlBase)
            };

            var response = await client.PostAsJsonAsync(endpoint, body);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                return default;
            }
        }
    }
}
