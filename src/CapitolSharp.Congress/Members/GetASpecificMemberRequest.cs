using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetASpecificMember;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get biographical and Congressional role information for a particular member of Congress
    /// </summary>
    public class GetASpecificMemberRequest : ProPublicaApiRequest<GetASpecificMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("/members/{0}.json", MemberId);
    }
}
