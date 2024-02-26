using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class VotesTests(CapitolSharpCongressFixture fixture)
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Votes_GetRecentVotesAsync()
        {
            var sut = new Votes(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetRecentVotesAsync("house");
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task Votes_GetRoleCallVoteAsync()
        {
            var sut = new Votes(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetRoleCallVoteAsync("1", "house", "1", "1");
            Assert.False(string.IsNullOrEmpty(result?.roll_call));
        }
    }
}
