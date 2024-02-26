using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class StatementsTests(CapitolSharpCongressFixture fixture)
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Statements_GetRecentStatementsAsync()
        {
            var sut = new Statements(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetRecentStatementsAsync();
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task Statements_SearchStatementsAsync()
        {
            var sut = new Statements(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.SearchStatementsAsync("term");
            Assert.True(result?.Count > 0);
        }
    }
}
