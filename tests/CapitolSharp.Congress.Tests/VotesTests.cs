using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class VotesTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Votes sut = new(fixture.CongressApiMock.Object, fixture.Mapper);

        [Fact]
        public async Task GetRecentVotesAsync()
        {
            var result = await sut.GetRecentVotesAsync("house");
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task GetRoleCallVoteAsync()
        {
            var result = await sut.GetRoleCallVoteAsync("1", "house", "1", "1");
            Assert.False(string.IsNullOrEmpty(result?.roll_call));
        }

        [Fact]
        public async Task GetMemberExplanationsAsync()
        {
            var actual = await sut.GetMemberExplanationsAsync("1", "1");
            Assert.True(actual?.Count > 0);
        }
    }
}
