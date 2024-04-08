using CapitolSharp.Congress.Members;
using CapitolSharp.Congress.Tests.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Tests
{
    [Collection("Congress collection")]
    public class MembersTests(CapitolSharpFixture fixture) : IAsyncLifetime
    {
        public Task InitializeAsync() => Task.CompletedTask;

        [Theory]
        [InlineData(typeof(CompareTwoMembersBillSponsorshipsRequest), "CompareTwoMembersBillSponsorships")]
        [InlineData(typeof(CompareTwoMembersVotePositionsRequest), "CompareTwoMembersVotePositions")]
        [InlineData(typeof(GetASpecificMemberRequest), "GetASpecificMember")]
        [InlineData(typeof(GetASpecificMembersVotePositionsRequest), "GetASpecificMembersVotePositions")]
        [InlineData(typeof(GetBillsCosponsoredByASpecificMemberRequest), "GetBillsCosponsoredByASpecificMember")]
        [InlineData(typeof(GetCurrentMembersByDistrictRequest), "GetCurrentMembersByDistrict")]
        [InlineData(typeof(GetCurrentMembersByStateRequest), "GetCurrentMembersByState")]
        [InlineData(typeof(GetMembersLeavingOfficeRequest), "GetMembersLeavingOffice")]
        [InlineData(typeof(GetNewMembersRequest), "GetNewMembers")]
        [InlineData(typeof(GetQuarterlyOfficeExpensesByASpecificHouseMemberRequest), "GetQuarterlyOfficeExpensesByASpecificHouseMember")]
        [InlineData(typeof(GetQuarterlyOfficeExpensesByCategoryForASpecificHouseMemberRequest), "GetQuarterlyOfficeExpensesByCategoryForASpecificHouseMember")]
        [InlineData(typeof(GetQuarterlyOfficeExpensesForASpecifiedCategoryRequest), "GetQuarterlyOfficeExpensesForASpecifiedCategory")]
        [InlineData(typeof(GetRecentPrivatelyFundedTripsByASpecificHouseMemberRequest), "GetRecentPrivatelyFundedTripsByASpecificHouseMember")]
        [InlineData(typeof(GetRecentPrivatelyFundedTripsRequest), "GetRecentPrivatelyFundedTrips")]
        [InlineData(typeof(ListMembersRequest), "ListMembers")]
        public async Task Members_SendRequest(Type requestType, string resourceName)
        {
            dynamic request = Activator.CreateInstance(requestType);

            await fixture.MockHttpResponseMessage(request, $"Members/{resourceName}.json");

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
