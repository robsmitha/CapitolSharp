using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    public class BillsTests(CapitolSharpCongressFixture fixture)
        : IClassFixture<CapitolSharpCongressFixture>
    {
        [Fact]
        public async Task Bills_GetUpcomingBillsAsync()
        {
            var sut = new Bills(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetUpcomingBillsAsync("house");
            Assert.True(result?.Count > 0);
        }

        [Fact]
        public async Task Bills_GetBillAsync()
        {
            var sut = new Bills(fixture.CongressApiMock.Object, fixture.Mapper);
            var result = await sut.GetBillAsync("1", "hr7023");
            Assert.False(string.IsNullOrEmpty(result?.bill_slug));
        }
    }
}
