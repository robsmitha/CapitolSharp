using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                using var client = CreateCongressApiClient(_apiKey);
                var response = await client.GetAsync(function, cancellationToken);
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
