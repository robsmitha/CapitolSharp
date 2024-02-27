using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;

namespace CapitolSharp.Congress.Tests
{
    public class MembersTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Members sut = new(fixture.CongressApiMock.Object, fixture.Mapper);

        [Fact]
        public async Task GetMembersAsync()
        {
            var actual = await sut.GetMembersAsync("1", "house");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberAsync()
        {
            var actual = await sut.GetMemberAsync("1");
            Assert.False(string.IsNullOrEmpty(actual?.id));
        }

        [Fact]
        public async Task CompareVotePositionsAsync()
        {
            var actual = await sut.CompareVotePositionsAsync("1", "1", "1", "house");
            Assert.False(string.IsNullOrEmpty(actual?.first_member_id));
        }

        [Fact]
        public async Task GetCurrentSenateMembersAsync()
        {
            var actual = await sut.GetCurrentSenateMembersAsync("house", "FL");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMembersLeavingAsync()
        {
            var actual = await sut.GetMembersLeavingAsync("house", "FL");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetNewMembersAsync()
        {
            var actual = await sut.GetNewMembersAsync();
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberVotesAsync()
        {
            var actual = await sut.GetMemberVotesAsync("1");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberBillsAsync()
        {
            var actual = await sut.GetMemberBillsAsync("1");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberCosponsoredBillsAsync()
        {
            var actual = await sut.GetMemberCosponsoredBillsAsync("1");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberStatementsAsync()
        {
            var actual = await sut.GetMemberStatementsAsync("1");
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberExpensesAsync()
        {
            var actual = await sut.GetMemberExpensesAsync("1", 2020, 1);
            Assert.True(actual?.Count > 0);
        }

        [Fact]
        public async Task GetMemberExplanationsAsync()
        {
            var actual = await sut.GetMemberExplanationsAsync("1", "1");
            Assert.True(actual?.Count > 0);
        }
    }
}