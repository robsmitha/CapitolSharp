using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class LobbyingTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Lobbying sut = new(fixture.CongressApiMock.Object, fixture.Mapper);
        
        [Fact]
        public async Task GetRecentLobbyingRepresentationsAsync()
        {
            var result = await sut.GetRecentLobbyingRepresentationsAsync();
            Assert.True(result?.Count > 0);
        }
    }
}
