using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetASpecificMembersVotePositions;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get the most recent vote positions for a specific member of the House of Representatives or Senate.
    /// </summary>
    public class GetASpecificMembersVotePositionsRequest : ProPublicaApiRequestPaged<GetASpecificMembersVotePositionsResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/votes.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/votes.json?offset={1}", MemberId, Offset);
    }
}
