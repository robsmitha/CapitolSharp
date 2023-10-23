using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Votes;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Interfaces;

namespace CapitolSharp.Congress.Stores
{
    public class Votes : DataStoreAccessor, IVotes
    {
        public Votes(string apiKey, IMapper mapper)
            : base(apiKey, mapper)
        {

        }

        public async Task<List<VoteModel>> GetRecentVotesAsync(string chamber)
        {
            var response = await SendAsync<Response<RecentVotesResult>>($"{chamber}/votes/recent.json");
            if (response?.results == null) return new List<VoteModel>();
            var data = response.results.votes;
            return data != null
                ? _mapper.Map<List<VoteModel>>(data)
                : new List<VoteModel>();
        }

        public async Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber)
        {
            var response = await SendAsync<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json");
            if (response?.results == null) return new VoteModel();
            var data = response.results.votes.vote;
            return data != null
                ? _mapper.Map<VoteModel>(data)
                : new VoteModel();
        }
    }
}
