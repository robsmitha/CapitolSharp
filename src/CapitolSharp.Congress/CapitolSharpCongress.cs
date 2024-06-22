using CapitolSharp.Congress.Exceptions;
using CapitolSharp.Congress.Models;
using Newtonsoft.Json;
using System.Net;

namespace CapitolSharp.Congress
{
    public interface ICapitolSharpCongress
    {
        Task<T?> SendAsync<T>(JsonFormatApiRequest<T> request, CancellationToken cancellationToken = default);
    }

    public class CapitolSharpCongress(HttpClient httpClient, CongressApiSettings settings) : ICapitolSharpCongress
    {
        public async Task<T?> SendAsync<T>(JsonFormatApiRequest<T> request, CancellationToken cancellationToken = default)
        {
            try
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = request.Uri
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
                    HttpStatusCode.BadRequest => new CongressApiBadRequestException($"Bad Request – The request is improperly formed ({typeof(T)} )"),
                    HttpStatusCode.NotFound => new CongressApiNotFoundException($"The specified record(s) could not be found ({typeof(T)} )"),
                    HttpStatusCode.ServiceUnavailable => new CongressApiServiceUnavailableException($"The service is currently not working. Please try again later. ({typeof(T)})"),
                    HttpStatusCode.Forbidden => new CongressApiForbiddenException($"Forbidden – The request did not include an authorization header ({typeof(T)} )"),
                    HttpStatusCode.NotAcceptable => new CongressApiException($"Not Acceptable – The requested format for the request isn’t json or xml ({typeof(T)})"),
                    HttpStatusCode.InternalServerError => new CongressApiException($"Internal Server Error – Problem with the api server. Try again later. ({typeof(T)})"),
                    _ => new CongressApiException($"Unhandled api response error. StatusCode: {httpResponse.StatusCode} ({typeof(T)})"),
                };
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
