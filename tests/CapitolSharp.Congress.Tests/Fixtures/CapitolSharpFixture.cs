using CapitolSharp.Congress.Utilities;
using Moq;
using Moq.Protected;
using System.Net;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public class CapitolSharpFixture : IAsyncLifetime
    {
        public ICapitolSharpCongress? CapitolSharpCongress;

        public readonly Mock<HttpMessageHandler> MockHttpHandler = new(MockBehavior.Strict);
        private readonly string BinDirectory = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        public CapitolSharpFixture()
        {
            CapitolSharpCongress = new CapitolSharpCongress(new HttpClient(MockHttpHandler.Object), new ProPublicaApiSettings());
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task MockHttpResponseMessage<T>(ProPublicaApiRequest<T> request, string resourcePath)
        {
            var resourceLocation = Path.Combine(BinDirectory, "_contracts", resourcePath.Replace("/", "\\"));
            var json = await File.ReadAllTextAsync(resourceLocation);

            MockHttpHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m => IsExpectedUri(request, m)),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });
        }

        private static bool IsExpectedUri<T>(ProPublicaApiRequest<T> request, HttpRequestMessage httpRequest)
        {
            return request.Endpoint.ToString().Equals(httpRequest.RequestUri!.AbsoluteUri, StringComparison.InvariantCultureIgnoreCase);
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