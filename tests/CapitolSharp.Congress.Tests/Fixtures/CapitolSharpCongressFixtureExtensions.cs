using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Stores;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public static class CapitolSharpCongressFixtureExtensions
    {
        public static async Task MockResponse<T>(this Mock<ICongressApiClient> CongressApiMock,
            string regex, string resource)
        {
            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://smitha-cdn.s3.us-east-2.amazonaws.com/CapitolSharp/TestData/{resource}.json");
            CongressApiMock.Setup(m => m.SendAsync<T>(It.IsRegex(regex)))
                .ReturnsAsync(JsonConvert.DeserializeObject<T>(json));
        }
    }
}
