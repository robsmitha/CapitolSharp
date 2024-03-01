using CapitolSharp.Congress.Stores;
using Moq;
using Newtonsoft.Json;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public static class CapitolSharpCongressFixtureExtensions
    {
        public static async Task MockResponse<T>(this Mock<ICongressApiClient> CongressApiMock,
            string regex, string resource)
        {
            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://smitha-cdn.s3.us-east-2.amazonaws.com/CapitolSharp/TestData/{resource}.json");
            CongressApiMock.Setup(m => m.SendAsync<T>(It.IsRegex(regex), It.IsAny<CancellationToken>()))
                .ReturnsAsync(JsonConvert.DeserializeObject<T>(json));
        }
    }
}
