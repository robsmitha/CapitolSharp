using CapitolSharp.Congress.Common;
using CapitolSharp.Congress.Bills.GetRecentBillsByASpecificMember;
using CapitolSharp.Congress.Options;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Get the 20 bills most recently introduced or updated by a particular member.
    /// <para>Results can include more than one Congress.</para>
    /// </summary>
    public class GetRecentBillsByASpecificMemberRequest : ProPublicaApiRequestPaged<GetRecentBillsByASpecificMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// The order of the results
        /// </summary>
        public BillSortOption Type { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/bills/{type}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("/members/{0}/bills/{1}.json?offset={2}", MemberId, Type.Serialize(), Offset);
    }
}
