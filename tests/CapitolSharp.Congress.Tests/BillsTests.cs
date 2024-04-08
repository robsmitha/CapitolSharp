using CapitolSharp.Congress.Bills;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Tests.Fixtures;
using Moq;

namespace CapitolSharp.Congress.Tests
{
    [Collection("Congress collection")]
    public class BillsTests(CapitolSharpFixture fixture) : IAsyncLifetime
    {
        public Task InitializeAsync() => Task.CompletedTask;

        [Fact]
        public async Task GetAmendmentsForASpecificBill()
        {
            var request = new GetAmendmentsForASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetAmendmentsForASpecificBill.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetASpecificBill()
        {
            var request = new GetASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetASpecificBill.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetASpecificBillSubject()
        {
            var request = new GetASpecificBillSubjectRequest
            {
                Query = "econonmy"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetASpecificBillSubject.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetCosponsorsForASpecificBill()
        {
            var request = new GetCosponsorsForASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetCosponsorsForASpecificBill.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetRecentBills()
        {
            var request = new GetRecentBillsRequest
            {
                Chamber = ChamberOption.Both,
                Congress = 116
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetRecentBills.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetRecentBillsByASpecificMember()
        {
            var request = new GetRecentBillsByASpecificMemberRequest
            {
                MemberId = "R000582",
                Type = BillSortOption.Active
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetRecentBillsByASpecificMember.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetRecentBillsByASpecificSubject()
        {
            var request = new GetRecentBillsByASpecificSubjectRequest
            {
                Subject = "immigration"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetRecentBillsByASpecificSubject.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetRelatedBillsForASpecificBill()
        {
            var request = new GetRelatedBillsForASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetRelatedBillsForASpecificBill.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetSubjectsForASpecificBill()
        {
            var request = new GetSubjectsForASpecificBillRequest
            {
                Congress = 115,
                BillId = "hr4881"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetSubjectsForASpecificBill.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task GetUpcomingBills()
        {
            var request = new GetUpcomingBillsRequest
            {
                Chamber = ChamberOption.House
            };

            await fixture.MockHttpResponseMessage(request, "Bills/GetUpcomingBills.json");

            var response = await fixture.CapitolSharpCongress!.SendAsync(request);

            Assert.Equal("OK", response?.Status, ignoreCase: true);
        }

        [Fact]
        public async Task SearchBills()
        {
            var request = new SearchBillsRequest
            {
                Query = "veterans"
            };

            await fixture.MockHttpResponseMessage(request, "Bills/SearchBills.json");

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
