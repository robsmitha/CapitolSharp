using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress
{
    public interface IVotes
    {
        Task<List<VoteModel>> GetRecentVotesAsync(string chamber);
        Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber);
    }
}
