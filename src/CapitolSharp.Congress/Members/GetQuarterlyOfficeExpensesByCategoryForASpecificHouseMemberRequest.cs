using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetQuarterlyOfficeExpensesByCategoryForASpecificHouseMember;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get the amount a given lawmaker spent during a specified year and quarter in a specified category
    /// </summary>
    public class GetQuarterlyOfficeExpensesByCategoryForASpecificHouseMemberRequest : ProPublicaApiRequest<GetQuarterlyOfficeExpensesByCategoryForASpecificHouseMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// Expense Category
        /// </summary>
        public ExpenseCategoryOption Category { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/office_expenses/category/{category}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/office_expenses/{1}.json", MemberId, Category);
    }
}
