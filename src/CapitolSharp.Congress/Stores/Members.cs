using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Responses.Statements;
using CapitolSharp.Congress.Responses.Votes;

namespace CapitolSharp.Congress.Stores
{
    public interface IMembers
    {
        Task<List<MemberModel>> GetMembersAsync(string congress, string chamber);
        Task<MemberModel> GetMemberAsync(string memberId);
        Task<CompareVotePositionsModel> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber);
        Task<List<MemberModel>> GetNewMembersAsync();
        Task<List<MemberModel>> GetMembersLeavingAsync(string congress, string chamber);
        Task<List<MemberModel>> GetCurrentSenateMembersAsync(string chamber, string state);
        Task<List<VoteModel>> GetMemberVotesAsync(string memberId);
        Task<List<BillModel>> GetMemberBillsAsync(string memberId);
        Task<List<BillModel>> GetMemberCosponsoredBillsAsync(string memberId);
        Task<List<StatementModel>> GetMemberStatementsAsync(string memberId);
        Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter);
        Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress);
    }
    public class Members(ICongressApiClient client, IMapper mapper) : IMembers
    {
        public async Task<MemberModel> GetMemberAsync(string memberId)
        {
            var response = await client.SendAsync<Response<List<Member>>>($"members/{memberId}.json");
            if (response?.results == null) return new MemberModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? mapper.Map<MemberModel>(data)
                : new MemberModel();
        }

        public async Task<List<MemberModel>> GetMembersAsync(string congress, string chamber)
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members.json");
            if (response?.results == null) return [];
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<CompareVotePositionsModel> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber)
        {
            var response = await client.SendAsync<Response<List<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");
            if (response?.results == null) return new CompareVotePositionsModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? mapper.Map<CompareVotePositionsModel>(data)
                : new CompareVotePositionsModel();
        }

        public async Task<List<MemberModel>> GetCurrentSenateMembersAsync(string chamber, string state)
        {
            var response = await client.SendAsync<Response<List<MemberListItem>>>($"members/{chamber}/{state}/current.json");
            if (response?.results == null) return [];
            var data = response?.results;
            return data != null
                ? mapper.Map<List<MemberModel>>(response?.results)
                : [];
        }

        public async Task<List<MemberModel>> GetMembersLeavingAsync(string congress, string chamber)
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.members;
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<List<MemberModel>> GetNewMembersAsync()
        {
            var response = await client.SendAsync<Response<List<MemberListResult>>>($"members/new.json");
            if (response?.results == null) return [];
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? mapper.Map<List<MemberModel>>(data)
                : [];
        }

        public async Task<List<VoteModel>> GetMemberVotesAsync(string memberId)
        {
            var response = await client.SendAsync<Response<IEnumerable<MemberVotesResult>>>($"members/{memberId}/votes.json");
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.votes;
            return data != null
                ? mapper.Map<List<VoteModel>>(data)
                : [];
        }

        public async Task<List<BillModel>> GetMemberBillsAsync(string memberId)
        {
            var response = await client.SendAsync<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/introduced.json");
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? mapper.Map<List<BillModel>>(data)
                : [];
        }

        public async Task<List<BillModel>> GetMemberCosponsoredBillsAsync(string memberId)
        {
            var response = await client.SendAsync<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/cosponsored.json");
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? mapper.Map<List<BillModel>>(data)
                : [];
        }

        public async Task<List<StatementModel>> GetMemberStatementsAsync(string memberId)
        {
            var response = await client.SendAsync<StatementResponse<List<Statement>>>($"members/{memberId}/statements.json");
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }

        public async Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter)
        {
            var response = await client.SendAsync<Response<IEnumerable<Expenses>>>($"members/{id}/office_expenses/{year}/{quarter}.json");
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<ExpensesModel>>(data)
                : [];
        }

        public async Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress)
        {
            var response = await client.SendAsync<Response<List<Explanation>>>($"members/{memberId}/explanations/{congress}.json");
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<ExplanationModel>>(data)
                : [];
        }
    }
}
