using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Votes;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Stores
{
    public interface IVotes
    {
        /// <summary>
        /// Get recent votes from the House, Senate or both chambers
        /// </summary>
        /// <param name="chamber"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<VoteModel>> GetRecentVotesAsync(string chamber, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a specific roll-call vote, including a complete list of member positions
        /// </summary>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="sessionNumber"></param>
        /// <param name="rollCallNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get recent personal explanations by a specific member
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="congress"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress, int offset = 0, CancellationToken cancellationToken = default);
    }

    public class Votes(ICongressApiClient client, IMapper mapper) : IVotes
    {
        public async Task<List<VoteModel>> GetRecentVotesAsync(string chamber, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<RecentVotesResult>>($"{chamber}/votes/recent.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results.votes;
            return data != null
                ? mapper.Map<List<VoteModel>>(data)
                : [];
        }

        public async Task<VoteModel> GetRoleCallVoteAsync(string congress, string chamber, string sessionNumber, string rollCallNumber, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<RollCallVoteResult>>($"{congress}/{chamber}/sessions/{sessionNumber}/votes/{rollCallNumber}.json", cancellationToken);
            if (response?.results == null) return new VoteModel();
            var data = response.results.votes.vote;
            return data != null
                ? mapper.Map<VoteModel>(data)
                : new VoteModel();
        }

        public async Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<Explanation>>>($"members/{memberId}/explanations/{congress}.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<ExplanationModel>>(data)
                : [];
        }
    }
}
