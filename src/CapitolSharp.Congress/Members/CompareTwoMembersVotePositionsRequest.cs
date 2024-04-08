using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.CompareTwoMembersVotePositions;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request type to compare two members’ vote positions in a particular Congress and chamber. 
    /// Responses include four calculated values, showing the number and percentage of votes in which the members took the same position or opposing positions.
    /// </summary>
    public class CompareTwoMembersVotePositionsRequest : ProPublicaApiRequest<CompareTwoMembersVotePositionsResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string FirstMemberId { get; set; } = "";

        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string SecondMemberId { get; set; } = "";

        /// <summary>
        /// Congress
        /// <para>102-117 for House, 101-117 for Senate</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// Chamber (house or senate)
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{first-member-id}/votes/{second-member-id}/{congress}/{chamber}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/votes/{1}/{2}/{3}.json", FirstMemberId, SecondMemberId, Congress, Chamber);
    }
}
