using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;

namespace CapitolSharp.Congress.Tests
{
    public class MembersTests(CapitolSharpCongressFixture fixture) : IClassFixture<CapitolSharpCongressFixture>
    {
        [Theory]
        [InlineData("house")]
        public async void Members_GetMembersAsync(string chamber)
        {
            var sut = new Members(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetMembersAsync("1", chamber);
            Assert.True(result?.Count > 0);
        }
    }
}