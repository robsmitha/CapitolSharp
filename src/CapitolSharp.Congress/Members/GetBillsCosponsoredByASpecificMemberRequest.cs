using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetBillsCosponsoredByASpecificMember;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get the 20 most recent bill cosponsorships for a particular member, either bills cosponsored or bills where cosponsorship was withdrawn.
    /// </summary>
    public class GetBillsCosponsoredByASpecificMemberRequest : ProPublicaApiRequestPaged<GetBillsCosponsoredByASpecificMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// Cosponsor type (cosponsored or withdrawn)
        /// </summary>
        public CosponsoredBillOption Type { get; set; }

        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/bills/{1}.json?offset={2}", MemberId, Type, Offset);
    }
}
