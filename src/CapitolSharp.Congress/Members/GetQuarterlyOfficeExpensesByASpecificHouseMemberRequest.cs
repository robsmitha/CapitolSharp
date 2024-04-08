using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetQuarterlyOfficeExpensesByASpecificHouseMember;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get the amount a given lawmaker spent during a specified year and quarter by category.
    /// </summary>
    public class GetQuarterlyOfficeExpensesByASpecificHouseMemberRequest : ProPublicaApiRequest<GetQuarterlyOfficeExpensesByASpecificHouseMemberResponse>
    {
        public string MemberId { get; set; } = "";

        /// <summary>
        /// Year
        /// <para>2009-2019</para>
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Quarter
        /// <para>1, 2, 3, 4</para>
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/office_expenses/{year}/{quarter}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/office_expenses/{1}/{2}.json", MemberId, Year, Quarter);
    }
}
