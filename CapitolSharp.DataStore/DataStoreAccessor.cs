using AutoMapper;
using System.Net;
using System.Text.Json;

namespace CapitolSharp.DataStore
{
    public abstract class DataStoreAccessor
    {
        protected IHttpClientFactory _httpClientFactory;
        protected IMapper _mapper;

        public DataStoreAccessor(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public virtual async Task<T?> SendAsync<T>(string function)
        {
            try
            {
                using var client = _httpClientFactory.CreateClient(DataStoreConstants.CONGRESS_API_CLIENT);
                var response = await client.GetAsync(function);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(json);
                }
                else
                {
                    throw new HttpRequestException($"{DataStoreConstants.CONGRESS_API_CLIENT} returned status code {response.StatusCode}");
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