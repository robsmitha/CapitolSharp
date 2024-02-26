using CapitolSharp.Congress.Interfaces;

namespace CapitolSharp.Congress
{
    public interface ICongressApiClient
    {
        IBills Bills { get; }
        ICommittees Committees { get; }
        ILobbying Lobbying { get; }
        IMembers Members { get; }
        IStatements Statements { get; }
        IVotes Votes { get; }
    }
}
