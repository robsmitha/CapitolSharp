using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Members;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Responses.Statements;
using CapitolSharp.Congress.Responses.Votes;
using CapitolSharp.Congress.Interfaces;

namespace CapitolSharp.Congress.Stores
{
    public class Members : DataStoreAccessor, IMembers
    {
        public Members(string apiKey) : base(apiKey)
        {

        }

        public async Task<CompareVotePositionsModel> CompareVotePositionsAsync(string firstMemberId, string secondMemberId, string congress, string chamber)
        {
            var response = await SendAsync<Response<List<CompareVotePositionsResult>>>($"members/{firstMemberId}/votes/{secondMemberId}/{congress}/{chamber}.json");
            if (response?.results == null) return new CompareVotePositionsModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? _mapper.Map<CompareVotePositionsModel>(data)
                : new CompareVotePositionsModel();
        }

        public async Task<List<MemberModel>> GetCurrentSenateMembersAsync(string chamber, string state)
        {
            var response = await SendAsync<Response<List<MemberListItem>>>($"members/{chamber}/{state}/current.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results;
            return data != null
                ? _mapper.Map<List<MemberModel>>(response?.results)
                : new List<MemberModel>();
        }

        public async Task<MemberModel> GetMemberAsync(string memberId)
        {
            var response = await SendAsync<Response<List<Member>>>($"members/{memberId}.json");
            if (response?.results == null) return new MemberModel();
            var data = response?.results.FirstOrDefault();
            return data != null
                ? _mapper.Map<MemberModel>(data)
                : new MemberModel();
        }

        public async Task<List<MemberModel>> GetMembersAsync(string congress, string chamber)
        {
            var response = await SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }

        public async Task<List<MemberModel>> GetMembersLeavingAsync(string congress, string chamber)
        {
            var response = await SendAsync<Response<List<MemberListResult>>>($"{congress}/{chamber}/members/leaving.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response.results.FirstOrDefault()?.members;
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }

        public async Task<List<MemberModel>> GetNewMembersAsync()
        {
            var response = await SendAsync<Response<List<MemberListResult>>>($"members/new.json");
            if (response?.results == null) return new List<MemberModel>();
            var data = response?.results.Select(m => m.members).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<MemberModel>>(data)
                : new List<MemberModel>();
        }

        public async Task<List<VoteModel>> GetMemberVotesAsync(string memberId)
        {
            var response = await SendAsync<Response<IEnumerable<MemberVotesResult>>>($"congress/members/{memberId}/votes");
            if (response?.results == null) return new List<VoteModel>();
            var data = response.results.FirstOrDefault()?.votes;
            return data != null
                ? _mapper.Map<List<VoteModel>>(data)
                : new List<VoteModel>();
        }

        public async Task<List<BillModel>> GetMemberBillsAsync(string memberId)
        {
            var response = await SendAsync<Response<IEnumerable<MemberBillsResult>>>($"congress/members/{memberId}/bills/introduced");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }

        public async Task<List<BillModel>> GetMemberCosponsoredBillsAsync(string memberId)
        {
            var response = await SendAsync<Response<IEnumerable<MemberBillsResult>>>($"congress/members/{memberId}/bills/cosponsored");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }

        public async Task<List<StatementModel>> GetMemberStatementsAsync(string memberId, string congress)
        {
            var response = await SendAsync<StatementResponse<List<Statement>>>($"congress/members/{memberId}/statements/{congress}");
            if (response?.results == null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }

        public async Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter)
        {
            var response = await SendAsync<Response<IEnumerable<Expenses>>>($"congress/members/office_expenses/{id}/{year}/{quarter}");
            if (response?.results == null) return new List<ExpensesModel>();
            var data = response.results;
            return _mapper.Map<List<ExpensesModel>>(data);
        }

        public async Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress)
        {
            var response = await SendAsync<Response<List<Explanation>>>($"congress/members/{memberId}/explanations/{congress}");
            if (response?.results == null) return new List<ExplanationModel>();
            var data = response.results;
            return _mapper.Map<List<ExplanationModel>>(data);
        }
    }
}
