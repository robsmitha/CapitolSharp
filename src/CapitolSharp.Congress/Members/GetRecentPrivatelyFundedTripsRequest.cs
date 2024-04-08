using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetRecentPrivatelyFundedTrips;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get a list of privately funded trips reported by all House members and staff in a particular Congress.
    /// </summary>
    public class GetRecentPrivatelyFundedTripsRequest : ProPublicaApiRequestPaged<GetRecentPrivatelyFundedTripsResponse>
    {
        /// <summary>
        /// Congress
        /// <para>105-117</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/{congress}/private-trips.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("{0}/private-trips.json?offset={1}", Congress, Offset);
    }
}
