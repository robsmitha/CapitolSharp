using AutoMapper;
using System.Reflection;
using System.Text.Json;

namespace CapitolSharp.Congress.Stores
{
    public abstract class DataStoreAccessor
    {
        private readonly string _apiKey;
        protected readonly IMapper _mapper;

        public DataStoreAccessor(string apiKey)
        {
            _apiKey = apiKey;

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
            _mapper = configuration.CreateMapper();
        }

        public virtual async Task<T?> SendAsync<T>(string function)
        {
            try
            {
                using var client = CreateCongressApiClient(_apiKey);
                var response = await client.GetAsync(function);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(json);
                }
                else
                {
                    throw new HttpRequestException($"{function} returned status code {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                // TODO: Edge cases (ProPublic Rate Limit, Transient Errors, etc.)
                throw e;
            }
        }

        private static HttpClient CreateCongressApiClient(string apiKey)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.propublica.org/congress/v1")
            };
            client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            return client;
        }
    }
}