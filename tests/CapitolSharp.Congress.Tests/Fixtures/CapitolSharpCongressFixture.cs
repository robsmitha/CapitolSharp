using AutoMapper;
using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Stores;
using Moq;
using CapitolSharp.Congress.Responses.Bills;
using CapitolSharp.Congress.Responses.Votes;
using CapitolSharp.Congress.Responses.Statements;
using CapitolSharp.Congress.Responses.Committee;
using CapitolSharp.Congress.Responses.Lobbying;

namespace CapitolSharp.Congress.Tests.Fixtures
{
    public class CapitolSharpCongressFixture : IAsyncLifetime
    {
        public readonly IMapper Mapper;
        public readonly Mock<ICongressApiClient> CongressApiMock;

        public CapitolSharpCongressFixture()
        {
            CongressApiMock = new Mock<ICongressApiClient>();
            Mapper = new MapperConfiguration(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies())).CreateMapper();
        }

        public async Task InitializeAsync()
        {
            // Bills
            await CongressApiMock.MockResponse<BillsResponse<List<UpcomingBills>>>(@"bills/upcoming/(?i:house|senate)\.json", "bills-GetUpcomingBills");
            await CongressApiMock.MockResponse<BillsResponse<List<Bill>>>(@"^\w+/bills/\w+\.json$", "bills-GetBill");

            // Committee
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeResult>>>(@"^\w+/\w+/committees/\w+\.json$", "committees-GetCommittee");
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeListResult>>>(@"^\w+/\w+/committees\.json$", "committees-GetCommittees");

            // Lobbying
            await CongressApiMock.MockResponse<Response<IEnumerable<LobbyingListResult>>>(@"^\/lobbying\/latest\.json$", "lobbying-GetRecentLobbyingRepresentations");

            // Members
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"\w+/(?i:house|senate)/members\.json", "members-GetMembers");
            await CongressApiMock.MockResponse<Response<List<Member>>>(@"members/\w+\.json$", "members-GetMember");
            await CongressApiMock.MockResponse<Response<List<CompareVotePositionsResult>>>(@"^members\/\w+\/votes\/\w+\/\w+\/\w+\.json$", "members-CompareVotePositions");
            await CongressApiMock.MockResponse<Response<List<MemberListItem>>>(@"^members\/\w+\/\w+\/current\.json$", "members-GetCurrentSenateMembers");
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"^\w+\/\w+\/members\/leaving\.json$", "members-GetMembersLeaving");
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"^members\/new\.json$", "members-GetNewMembers");
            await CongressApiMock.MockResponse<Response<IEnumerable<MemberVotesResult>>>(@"^members\/\w+\/votes\.json$", "members-GetMemberVotes");
            await CongressApiMock.MockResponse<Response<IEnumerable<MemberBillsResult>>>(@"^members\/\w+\/bills\/introduced\.json$", "members-GetMemberBills");
            await CongressApiMock.MockResponse<Response<IEnumerable<MemberBillsResult>>>(@"^members\/\w+\/bills\/cosponsored\.json$", "members-GetMemberCosponsoredBills");
            await CongressApiMock.MockResponse<StatementResponse<List<Statement>>>(@"^members\/\w+\/statements\.json$", "members-GetMemberStatements");
            await CongressApiMock.MockResponse<Response<IEnumerable<Expenses>>>(@"members\/\w+\/office_expenses\/\w+\/\w+\.json", "members-GetMemberExpenses");
            await CongressApiMock.MockResponse<Response<List<Explanation>>>(@"members\/\w+\/explanations\/\w+\.json", "members-GetMemberExplanations");

            // Statements
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"^\/statements\/latest\.json$", "statements-GetRecentStatements");
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"^/statements/search\.json\?query=.+$", "statements-SearchStatements");

            // Votes
            await CongressApiMock.MockResponse<Response<RecentVotesResult>>(@"^\w+/votes/recent.json$", "votes-GetRecentVotes");
            await CongressApiMock.MockResponse<Response<RollCallVoteResult>>(@"^\w+/\w+/sessions/\w+/votes/\w+\.json$", "votes-GetRoleCallVote");
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}