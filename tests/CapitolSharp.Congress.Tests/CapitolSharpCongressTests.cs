﻿using CapitolSharp.Congress.Bills;
using CapitolSharp.Congress.Tests.Fixtures;
using Moq;

namespace CapitolSharp.Congress.Tests
{
    [Collection("Congress collection")]
    public class CapitolSharpCongressTests(CongressFixture fixture) : IAsyncLifetime
    {
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task SearchBillsRequest()
        {
            var request = new SearchBillsRequest
            {
                Query = "veterans"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/SearchBills");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetASpecificBillRequest()
        {
            var request = new GetASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetASpecificBill");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetRecentBillsByASpecificMemberRequest()
        {
            var request = new GetRecentBillsByASpecificMemberRequest
            {
                MemberId = "R000582",
                Type = GetRecentBillsByASpecificMemberTypeOption.Active
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetRecentBillsByASpecificMember");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        public Task DisposeAsync()
        {
            fixture.MockHttpHandler.Reset();
            return Task.CompletedTask;
        }
    }
}
