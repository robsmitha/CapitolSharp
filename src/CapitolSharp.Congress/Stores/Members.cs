using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Stores
{
    public interface IMembers
    {
        /// <summary>
        /// Get a list of members of a particular chamber in a particular Congress. 
        /// The results include all members who have served in that congress and chamber, including members who are no longer in office.
        /// </summary>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<MemberModel>> GetMembersAsync(string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get biographical and Congressional role information for a particular member of Congress
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MemberModel> GetMemberAsync(string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of the most recent new members of the current Congress
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<MemberModel>> GetNewMembersAsync(int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of senate members in the current congress
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<List<MemberModel>> GetCurrentSenateMembersAsync(string state, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of members who have left the Senate or House or have announced plans to do so
        /// </summary>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<MemberModel>> GetMembersLeavingAsync(string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the most recent vote positions for a specific member of the House of Representatives or Senate
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<VoteModel>> GetMemberVotesAsync(string memberId, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// compare two members’ vote positions in a particular Congress and chamber. 
        /// Responses include four calculated values, showing the number and percentage of votes in which the members took the same position or opposing positions.
        /// </summary>
        /// <param name="firstMemberId"></param>
        /// <param name="secondMemberId"></param>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CompareVotePositionsModel> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the amount a given lawmaker spent during a specified year and quarter by category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter, int offset = 0, CancellationToken cancellationToken = default);
    }
    public class Members(ICongressApiClient client, IMapper mapper) : IMembers
    {
        public async Task<List<MemberModel>> GetMembersAsync(string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<MemberModel> GetMemberAsync(string memberId, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<Member>>>($"members/{memberId}.json", cancellationToken);
            if (response?.results == null) return new MemberModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? mapper.Map<MemberModel>(data)
                : new MemberModel();
        }

        public async Task<List<MemberModel>> GetNewMembersAsync(int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"members/new.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<List<MemberModel>> GetCurrentSenateMembersAsync(string state, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<MemberListItem>>>($"members/senate/{state}/current.json", cancellationToken);
            if (response?.results == null) return [];
            var data = response?.results;
            return data != null
                ? mapper.Map<List<MemberModel>>(response?.results)
                : [];
        }

        public async Task<List<MemberModel>> GetMembersLeavingAsync(string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.members;
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<List<VoteModel>> GetMemberVotesAsync(string memberId, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<MemberVotesResult>>>($"members/{memberId}/votes.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.votes;
            return data != null
                ? mapper.Map<List<VoteModel>>(data)
                : [];
        }

        public async Task<CompareVotePositionsModel> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<List<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json?offset={offset}", cancellationToken);
            if (response?.results == null) return new CompareVotePositionsModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? mapper.Map<CompareVotePositionsModel>(data)
                : new CompareVotePositionsModel();
        }

        public async Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<Expenses>>>($"members/{id}/office_expenses/{year}/{quarter}.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<ExpensesModel>>(data)
                : [];
        }
    }
}
