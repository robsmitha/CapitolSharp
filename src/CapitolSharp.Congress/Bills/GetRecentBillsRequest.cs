using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Bills.GetRecentBills;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request type to get summaries of the 20 most recent bills by type.
    /// For the current Congress, “recent bills” can be one of four types (see the descriptions below).
    /// For previous Congresses, “recent bills” means the last 20 bills of that Congress. 
    /// In the responses, an active value of true means that the bill has seen action beyond introduction and committee referral.
    /// </summary>
    public class GetRecentBillsRequest : ProPublicaApiRequestPaged<GetRecentBillsResponse>
    {
        /// <summary>
        /// The congress
        /// <para>Supported: 105-117</para>
        /// <para>Bills before the 113th Congress (prior to 2013) have fewer attribute values than those from the 113th Congress onward.</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// The chamber (house, senate or both)
        /// </summary>
        public ChamberOption Chamber { get; set; }

        /// <summary>
        /// The order of the results
        /// </summary>
        public BillSortOption Type { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/{congress}/{chamber}/bills/{type}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("{0}/{1}/bills/{2}.json?offset={3}", Congress, Chamber, Type, Offset);
    }
}
