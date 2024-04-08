using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Members.GetCurrentMembersByDistrict;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get biographical and Congressional role information for current house members by state and district.
    /// </summary>
    public class GetCurrentMembersByDistrictRequest : ProPublicaApiRequest<GetCurrentMembersByDistrictResponse>
    {
        /// <summary>
        /// The chamber (house or senate)
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// Two-letter state abbreviation
        /// </summary>
        public string State { get; set; } = "";

        /// <summary>
        /// House of Representatives district number
        /// <para>For states with at-large districts (AK, DE, MT, ND, SD, VT, WY), territories (GU, AS, VI, MP), commonwealths (PR) and the District of Columbia, use a district value of 1</para>
        /// </summary>
        public int District { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{chamber}/{state}/{district}/current.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/{1}/{2}/current.json", Chamber, State, District);
    }
}
