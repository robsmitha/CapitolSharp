using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class BillsTests(CapitolSharpCongressFixture fixture) : CongressApiTest
    {
        private readonly Bills sut = new(fixture.CongressApiMock.Object, fixture.Mapper);

        [Fact]
        public async Task GetUpcomingBillsAsync()
        {
            var result = await sut.GetUpcomingBillsAsync("house");
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task GetBillAsync()
        {
            var result = await sut.GetBillAsync("1", "hr7023");
            Assert.False(string.IsNullOrEmpty(result?.bill_slug));
        }

        [Fact]
        public async Task GetMemberBillsAsync()
        {
            var actual = await sut.GetMemberBillsAsync("1", "introduced");
            Assert.True(actual?.Count > 0);
        }
    }
}
