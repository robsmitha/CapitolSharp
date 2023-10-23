using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress.Interfaces
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
        Task<List<StatementModel>> GetMemberStatementsAsync(string memberId, string congress);
        Task<List<ExpensesModel>> GetMemberExpensesAsync(string id, int year, int quarter);
        Task<List<ExplanationModel>> GetMemberExplanationsAsync(string memberId, string congress);
    }
}
