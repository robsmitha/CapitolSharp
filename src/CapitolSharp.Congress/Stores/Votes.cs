using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Votes;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Stores
{
    public interface IVotes
    {
        Task<List<VoteModel>> GetRecentVotesAsync(string chamber);
        Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber);
    }

    public class Votes(ICongressApiClient client, IMapper mapper) : IVotes
    {
        public async Task<List<VoteModel>> GetRecentVotesAsync(string chamber)
        {
            var response = await client.SendAsync<Response<RecentVotesResult>>($"{chamber}/votes/recent.json");
            if (response?.results == null) return [];
            var data = response.results.votes;
            return data != null
                ? mapper.Map<List<VoteModel>>(data)
                : [];
        }

        public async Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber)
        {
            var response = await client.SendAsync<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json");
            if (response?.results == null) return new VoteModel();
            var data = response.results.votes.vote;
            return data != null
                ? mapper.Map<VoteModel>(data)
                : new VoteModel();
        }
    }
}
