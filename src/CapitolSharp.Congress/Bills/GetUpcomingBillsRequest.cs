using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Bills.GetUpcomingBills;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request type to get details on bills that may be considered by the House or Senate in the near future,
    /// based on scheduled published or announced by congressional leadership.
    /// </summary>
    public class GetUpcomingBillsRequest : ProPublicaApiRequest<GetUpcomingBillsResponse>
    {
        /// <summary>
        /// The chamber (house or senate)
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/bills/upcoming/{chamber}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("/bills/upcoming/{0}.json", Chamber);
    }
}
