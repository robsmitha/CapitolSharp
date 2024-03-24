using System.Text.Json;

namespace CapitolSharp.Congress.Stores
{
    public interface ICongressApiClient
    {
        Task<T?> SendAsync<T>(string function, CancellationToken cancellationToken = default);
    }

    public class CongressApiClient : ICongressApiClient
    {
        private readonly string _apiKey;

        public CongressApiClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<T?> SendAsync<T>(string function, CancellationToken cancellationToken = default)
        {
            try
            {
                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.propublica.org/congress/v1{(function.StartsWith('/') ? function : '/' + function)}")
                };
                httpRequestMessage.Headers.Add("X-API-Key", _apiKey);

                using var client = new HttpClient();
                var response = await client.SendAsync(httpRequestMessage, cancellationToken);
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync(cancellationToken);
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
                throw;
            }
        }
    }
}
