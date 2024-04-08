using CapitolSharp.Congress.Bills;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Members;
using CapitolSharp.Congress.Tests.Fixtures;
using Moq;

namespace CapitolSharp.Congress.Tests
{
    [Collection("Congress collection")]
    public class BillsTests(CapitolSharpFixture fixture) : IAsyncLifetime
    {
        public Task InitializeAsync() => Task.CompletedTask;

        [Theory]
        [InlineData(typeof(GetAmendmentsForASpecificBillRequest), "GetAmendmentsForASpecificBill")]
        [InlineData(typeof(GetASpecificBillRequest), "GetASpecificBill")]
        [InlineData(typeof(GetASpecificBillSubjectRequest), "GetASpecificBillSubject")]
        [InlineData(typeof(GetCosponsorsForASpecificBillRequest), "GetCosponsorsForASpecificBill")]
        [InlineData(typeof(GetRecentBillsRequest), "GetRecentBills")]
        [InlineData(typeof(GetRecentBillsByASpecificMemberRequest), "GetRecentBillsByASpecificMember")]
        [InlineData(typeof(GetRecentBillsByASpecificSubjectRequest), "GetRecentBillsByASpecificSubject")]
        [InlineData(typeof(GetRelatedBillsForASpecificBillRequest), "GetRelatedBillsForASpecificBill")]
        [InlineData(typeof(GetSubjectsForASpecificBillRequest), "GetSubjectsForASpecificBill")]
        [InlineData(typeof(GetUpcomingBillsRequest), "GetUpcomingBills")]
        [InlineData(typeof(SearchBillsRequest), "SearchBills")]
        public async Task Bills_SendRequest(Type requestType, string resourceName)
        {
            dynamic request = Activator.CreateInstance(requestType);

            await fixture.MockHttpResponseMessage(request, $"Bills/{resourceName}.json");

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
