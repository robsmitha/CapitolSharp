using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.CompareTwoMembersBillSponsorships;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to compare bill sponsorship between two members who served in the same Congress and chamber.
    /// </summary>
    public class CompareTwoMembersBillSponsorshipsRequest : ProPublicaApiRequest<CompareTwoMembersBillSponsorshipsResponse>
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
        /// GET https://api.propublica.org/congress/v1/members/{first-member-id}/bills/{second-member-id}/{congress}/{chamber}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/bills/{1}/{2}/{3}.json", FirstMemberId, SecondMemberId, Congress, Chamber);
    }
}
