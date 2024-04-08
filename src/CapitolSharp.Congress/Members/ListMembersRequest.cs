using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.ListMembers;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get a list of members of a particular chamber in a particular Congress.
    /// The results include all members who have served in that congress and chamber, including members who are no longer in office.
    /// </summary>
    public class ListMembersRequest : ProPublicaApiRequestPaged<ListMembersResponse>
    {
        /// <summary>
        /// The congress
        /// <para>102-117 for House, 80-117 for Senate</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// The chamber (house, senate)
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/{congress}/{chamber}/members.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("{0}/{1}/members.json?offset={2}", Congress, Chamber, Offset);
    }
}
