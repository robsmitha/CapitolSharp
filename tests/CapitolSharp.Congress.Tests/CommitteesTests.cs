using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class CommitteesTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Committees sut = new(fixture.CongressApiMock.Object, fixture.Mapper);

        [Fact]
        public async Task GetCommitteeAsync()
        {
            var result = await sut.GetCommitteeAsync("1", "1", "house");
            Assert.False(string.IsNullOrEmpty(result?.id));
        }

        [Fact]
        public async Task GetCommitteesAsync()
        {
            var result = await sut.GetCommitteesAsync("1", "house");
            Assert.True(result?.Count > 0);
        }
    }
}
