using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;

namespace CapitolSharp.Congress.Tests
{
    public class MembersTests(CapitolSharpCongressFixture fixture) 
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Members_GetMembersAsync()
        {
            var sut = new Members(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetMembersAsync("1", "house");
            Assert.True(result?.Count > 0);
        }
    }
}