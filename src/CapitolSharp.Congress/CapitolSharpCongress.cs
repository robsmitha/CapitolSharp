using CapitolSharp.Congress.Utilities;
using Newtonsoft.Json;
using System.Net;

namespace CapitolSharp.Congress
{
    public interface ICapitolSharpCongress
    {
        Task<T?> SendAsync<T>(ProPublicaApiRequest<T> request, CancellationToken cancellationToken = default);
    }

    public class CapitolSharpCongress(HttpClient httpClient, ProPublicaApiSettings settings) : ICapitolSharpCongress
    {
        public async Task<T?> SendAsync<T>(ProPublicaApiRequest<T> request, CancellationToken cancellationToken = default)
        {
            try
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(request.Endpoint)
                };

                httpRequest.Headers.Add("X-API-Key", settings.ApiKey);

                var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var json = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
                    return JsonConvert.DeserializeObject<T>(json);
                }

                throw httpResponse.StatusCode switch
                {
                    HttpStatusCode.BadRequest => new ProPublicaApiException($"Bad Request – The request is improperly formed ({typeof(T)} )"),
                    HttpStatusCode.Forbidden => new ProPublicaApiException($"Forbidden – The request did not include an authorization header ({typeof(T)} )"),
                    HttpStatusCode.NotFound => new ProPublicaApiException($"Not Found – The specified record(s) could not be found ({typeof(T)} )"),
                    HttpStatusCode.NotAcceptable => new ProPublicaApiException($"Not Acceptable – The requested format for the request isn’t json or xml ({typeof(T)})"),
                    HttpStatusCode.InternalServerError => new ProPublicaApiException($"Internal Server Error – Problem with the api server. Try again later. ({typeof(T)})"),
                    HttpStatusCode.ServiceUnavailable => new ProPublicaApiException($"Service Unavailable – The service is currently not working. Please try again later. ({typeof(T)})"),
                    _ => new ProPublicaApiException($"Unhandled api response error. StatusCode: {httpResponse.StatusCode} ({typeof(T)})"),
                };
            }
            catch (HttpRequestException)
            {
                // TODO: Edge cases (ProPublic Rate Limit, Transient Errors, etc.)
                throw;
            }
        }
    }
}
