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
            Bills = new Bills(apiKey);
            Committees = new Committees(apiKey);
            Lobbying = new Lobbying(apiKey);
            Members = new Members(apiKey);
            Statements = new Statements(apiKey);
            Votes = new Votes(apiKey);
        }

        public IBills Bills { get; private set; }
        public ICommittees Committees { get; private set; }
        public ILobbying Lobbying { get; private set; }
        public IMembers Members { get; private set; }
        public IStatements Statements { get; private set; }
        public IVotes Votes { get; private set; }
    }
}
