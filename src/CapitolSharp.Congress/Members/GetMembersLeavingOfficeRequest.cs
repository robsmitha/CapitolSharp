using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetMembersLeavingOffice;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get a list of members who have left the Senate or House or have announced plans to do so.
    /// </summary>
    public class GetMembersLeavingOfficeRequest : ProPublicaApiRequestPaged<GetMembersLeavingOfficeResponse>
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

        internal override ProPublicaApiEndpoint Endpoint => new("{0}/{1}/members/leaving.json?offset={2}", Congress, Chamber, Offset);
    }
}
