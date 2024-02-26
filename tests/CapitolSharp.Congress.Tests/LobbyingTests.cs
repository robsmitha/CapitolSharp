using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class LobbyingTests(CapitolSharpCongressFixture fixture)
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Lobbying_GetRecentLobbyingRepresentationsAsync()
        {
            var sut = new Lobbying(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetRecentLobbyingRepresentationsAsync();
            Assert.True(result?.Count > 0);
        }
    }
}
