using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class CommitteesTests(CapitolSharpCongressFixture fixture)
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Committees_GetCommitteeAsync()
        {
            var sut = new Committees(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetCommitteeAsync("1", "1", "house");
            Assert.False(string.IsNullOrEmpty(result?.id));
        }

        [Fact]
        public async Task Committees_GetCommitteesAsync()
        {
            var sut = new Committees(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetCommitteesAsync("1", "house");
            Assert.True(result?.Count > 0);
        }
    }
}
