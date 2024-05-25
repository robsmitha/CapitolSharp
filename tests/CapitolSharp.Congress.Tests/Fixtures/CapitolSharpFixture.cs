using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Settings;
using Moq;
using Moq.Protected;
using System;
using System.Net;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public class CapitolSharpFixture : IAsyncLifetime
    {
        public ICapitolSharpCongress? CapitolSharpCongress;

        public readonly Mock<HttpMessageHandler> MockHttpHandler = new(MockBehavior.Strict);

        public CapitolSharpFixture()
        {
            CapitolSharpCongress = new CapitolSharpCongress(new HttpClient(MockHttpHandler.Object), new CongressApiSettings());
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task MockHttpResponseMessage<T>(JsonFormatApiRequest<T> request, string resourcePath)
        {
            var resourceLocation = "https://smitha-cdn.s3.us-east-2.amazonaws.com/CapitolSharp/sample-json/";
            using var client = new HttpClient();
            var response = await client.GetAsync(resourceLocation + resourcePath);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                MockHttpHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.Is<HttpRequestMessage>(httpRequestMessge => request.Uri.Equals(httpRequestMessge.RequestUri)),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(json)
                    });

            }
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }


    [CollectionDefinition("Congress collection")]
    public class CongressCollection : ICollectionFixture<CapitolSharpFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}