using AutoMapper;
using CapitolSharp.Congress.Stores;
using System.Reflection;

namespace CapitolSharp.Congress
{
    public class CapitolSharpCongress(string apiKey)
    {
        private readonly ICongressApiClient api = new CongressApiClient(apiKey);
        private readonly IMapper mapper = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly())).CreateMapper();

        private IBills? _bills;
        private ICommittees? _committees;
        private ILobbying? _lobbying;
        private IMembers? _members;
        private IStatements? _statements;
        private IVotes? _votes;

        public IBills Bills => _bills ??= new Bills(api, mapper);
        public ICommittees Committees => _committees ??= new Committees(api, mapper);
        public ILobbying Lobbying => _lobbying ??= new Lobbying(api, mapper);
        public IMembers Members => _members ??= new Members(api, mapper);
        public IStatements Statements => _statements ??= new Statements(api, mapper);
        public IVotes Votes => _votes ??= new Votes(api, mapper);
    }
}
