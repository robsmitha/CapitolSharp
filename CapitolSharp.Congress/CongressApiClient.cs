using AutoMapper;
using CapitolSharp.Congress.Interfaces;
using CapitolSharp.Congress.Stores;
using System.Reflection;

namespace CapitolSharp.Congress
{
    public class CongressApiClient : ICongressApiClient
    {
        public CongressApiClient(string apiKey)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
            var mapper = configuration.CreateMapper();

            // TODO: Extension method

            Bills = new Bills(apiKey, mapper);
            Committees = new Committees(apiKey, mapper);
            Lobbying = new Lobbying(apiKey, mapper);
            Members = new Members(apiKey, mapper);
            Statements = new Statements(apiKey, mapper);
            Votes = new Votes(apiKey, mapper);
        }

        public IBills Bills { get; private set; }
        public ICommittees Committees { get; private set; }
        public ILobbying Lobbying { get; private set; }
        public IMembers Members { get; private set; }
        public IStatements Statements { get; private set; }
        public IVotes Votes { get; private set; }
    }
}
