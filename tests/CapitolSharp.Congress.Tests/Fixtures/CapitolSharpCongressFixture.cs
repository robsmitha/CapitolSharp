using AutoMapper;
using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Stores;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public class CapitolSharpCongressFixture : IAsyncLifetime
    {
        public readonly IMapper Mapper;
        public readonly Mock<ICongressApiClient> CongressApiMock;

        public CapitolSharpCongressFixture()
        {
            CongressApiMock = new Mock<ICongressApiClient>();
            Mapper = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies())).CreateMapper();
        }

        public async Task InitializeAsync()
        {
            using var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://smitha-cdn.s3.us-east-2.amazonaws.com/CapitolSharp/TestData/members-house.json");
            CongressApiMock.Setup(m => m.SendAsync<Response<List<MemberListResult>>>(It.IsRegex(@"\/house\/members\.json")))
                .ReturnsAsync(JsonConvert.DeserializeObject<Response<List<MemberListResult>>>(json));
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}
