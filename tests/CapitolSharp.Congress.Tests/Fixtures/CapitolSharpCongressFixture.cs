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
            await CongressApiMock.MockResponse<BillsResponse<List<UpcomingBills>>>(@"bills/upcoming/(?i:house|senate)\.json", "bills-upcoming");
            await CongressApiMock.MockResponse<BillsResponse<List<Bill>>>(@"^\w+/bills/\w+\.json$", "bills-bill");

            // Committee
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeResult>>>(@"^\w+/\w+/committees/\w+\.json$", "committees-committee");
            await CongressApiMock.MockResponse<Response<IEnumerable<CommitteeListResult>>>(@"^\w+/\w+/committees\.json$", "committees-committees");

            // Lobbying
            await CongressApiMock.MockResponse<Response<IEnumerable<LobbyingListResult>>>(@"^\/lobbying\/latest\.json$", "lobbying-latest");

            // Members
            await CongressApiMock.MockResponse<Response<List<MemberListResult>>>(@"\w+/(?i:house|senate)/members\.json", "members-members");

            // Statements
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"^\/statements\/latest\.json$", "statements-latest");
            await CongressApiMock.MockResponse<StatementResponse<IEnumerable<Statement>>>(@"^/statements/search\.json\?query=.+$", "statements-search");

            // Votes
            await CongressApiMock.MockResponse<Response<RecentVotesResult>>(@"^\w+/votes/recent.json$", "votes-recent");
            await CongressApiMock.MockResponse<Response<RollCallVoteResult>>(@"^\w+/\w+/sessions/\w+/votes/\w+\.json$", "votes-roll-call-vote");
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}