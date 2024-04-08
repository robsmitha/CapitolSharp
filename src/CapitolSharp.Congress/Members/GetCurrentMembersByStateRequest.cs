using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Members.GetCurrentMembersByState;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get biographical and Congressional role information for current house or senate members by state.
    /// </summary>
    public class GetCurrentMembersByStateRequest : ProPublicaApiRequest<GetCurrentMembersByStateResponse>
    {
        /// <summary>
        /// house or senate
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// Two-letter state abbreviation
        /// </summary>
        public string State { get; set; } = "";

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{chamber}/{state}/current.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/{0}/{1}/current.json", Chamber, State);
    }
}
