using AutoMapper;
using System.Text.Json;

namespace CapitolSharp.Congress.Stores
{
    public abstract class DataStoreAccessor
    {
        protected HttpClient _client;
        protected IMapper _mapper;

        public DataStoreAccessor(string apiKey, IMapper mapper)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.propublica.org/congress/v1")
            };
            _client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            _mapper = mapper;
        }

        public virtual async Task<T?> SendAsync<T>(string function)
        {
            try
            {
                var response = await _client.GetAsync(function);
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
    }
}