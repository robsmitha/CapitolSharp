using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class StatementsTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Statements sut = new(fixture.CongressApiMock.Object, fixture.Mapper);

        [Fact]
        public async Task GetRecentStatementsAsync()
        {
            var result = await sut.GetRecentStatementsAsync();
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task SearchStatementsAsync()
        {
            var result = await sut.SearchStatementsAsync("term");
            Assert.True(result?.Count > 0);
        }
    }
}
