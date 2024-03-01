using AutoMapper;
using Moq;
using CapitolSharp.Congress.Stores;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Responses.Members;
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
            await CongressApiMock.MockResponse<BillsResponse<List<UpcomingBills>>>(@"\/?bills\/upcoming\/[a-zA-Z0-9]+\.json?", "bills-GetUpcomingBills");
            await CongressApiMock.MockResponse<BillsResponse<List<Bill>>>(@"\/?[a-zA-Z0-9]+\/bills\/[a-zA-Z0-9]+\.json?", "bills-GetBill");
            await CongressApiMock.MockResponse<Response<IEnumerable<MemberBillsResult>>>(@"\/?members\/[a-zA-Z0-9]+\/bills\/[a-zA-Z0-9]+\.json?\?offset=[a-zA-Z0-9]+", "members-GetMemberBills");

            // Committee
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeResult>>>(@"\/?[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/committees\/[a-zA-Z0-9]+\.json", "committees-GetCommittee");
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeListResult>>>(@"\/?[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/committees\.json", "committees-GetCommittees");

            // Lobbying
            await CongressApiMock.MockResponse<Response<IEnumerable<LobbyingListResult>>>(@"\/?lobbying\/latest\.json\?offset=[a-zA-Z0-9]+", "lobbying-GetRecentLobbyingRepresentations");

            // Members
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"\/?[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/members\.json\?offset=[a-zA-Z0-9]+", "members-GetMembers");
            await CongressApiMock.MockResponse<Response<List<Member>>>(@"\/?members\/[a-zA-Z0-9]+\.json", "members-GetMember");
            await CongressApiMock.MockResponse<Response<List<CompareVotePositionsResult>>>(@"\/?members\/[a-zA-Z0-9]+\/votes\/[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/[a-zA-Z0-9]+\.json\?offset=[a-zA-Z0-9]+", "members-CompareVotePositions");
            await CongressApiMock.MockResponse<Response<List<MemberListItem>>>(@"\/?members\/senate\/[a-zA-Z0-9]+\/current\.json", "members-GetCurrentSenateMembers");
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"\/?[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/members\/leaving\.json\?offset=[a-zA-Z0-9]+", "members-GetMembersLeaving");
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"\/?members\/new\.json\?offset=[a-zA-Z0-9]+", "members-GetNewMembers");
            await CongressApiMock.MockResponse<Response<IEnumerable<MemberVotesResult>>>(@"\/?members\/[a-zA-Z0-9]+\/votes\.json\?offset=[a-zA-Z0-9]+", "members-GetMemberVotes");
            await CongressApiMock.MockResponse<Response<IEnumerable<Expenses>>>(@"\/?members\/[a-zA-Z0-9]+\/office_expenses\/[a-zA-Z0-9]+\/[a-zA-Z0-9]+\.json\?offset=[a-zA-Z0-9]+", "members-GetMemberExpenses");

            // Statements
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"\/?statements\/latest\.json\?offset=[a-zA-Z0-9]+", "statements-GetRecentStatements");
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"\/?statements\/search\.json\?query=[a-zA-Z0-9]+&offset=[a-zA-Z0-9]+", "statements-SearchStatements");
            await CongressApiMock.MockResponse<StatementResponse<List<Statement>>>(@"\/?members\/[a-zA-Z0-9]+\/statements\.json\?offset=[a-zA-Z0-9]+", "members-GetMemberStatements");

            // Votes
            await CongressApiMock.MockResponse<Response<RecentVotesResult>>(@"\/?[a-zA-Z0-9]+\/votes\/recent\.json\?offset=[a-zA-Z0-9]+", "votes-GetRecentVotes");
            await CongressApiMock.MockResponse<Response<RollCallVoteResult>>(@"\/?[a-zA-Z0-9]+\/[a-zA-Z0-9]+\/sessions\/[a-zA-Z0-9]+\/votes\/[a-zA-Z0-9]+\.json", "votes-GetRoleCallVote");
            await CongressApiMock.MockResponse<Response<List<Explanation>>>(@"\/?members\/[a-zA-Z0-9]+\/explanations\/[a-zA-Z0-9]+\.json\?offset=[a-zA-Z0-9]+", "members-GetMemberExplanations");
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}