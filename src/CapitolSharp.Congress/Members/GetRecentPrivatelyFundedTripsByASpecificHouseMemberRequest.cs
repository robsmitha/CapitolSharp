using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetRecentPrivatelyFundedTripsByASpecificHouseMember;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get a list of privately funded trips reported by a specific House member, including staff travel, in a particular Congress.
    /// </summary>
    public class GetRecentPrivatelyFundedTripsByASpecificHouseMemberRequest : ProPublicaApiRequestPaged<GetRecentPrivatelyFundedTripsByASpecificHouseMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/private-trips.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/private-trips.json?offset={1}", MemberId, Offset);
    }
}
