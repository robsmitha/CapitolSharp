﻿using CapitolSharp.Congress.Bills.GetASpecificBill;
using CapitolSharp.Congress.Common;

namespace CapitolSharp.Congress
{
    /// <summary>
    /// Get details about a particular bill, including actions taken and votes.
    /// </summary>
    public class GetASpecificBillRequest : ProPublicaApiRequest<GetASpecificBillResponse>
    {
        /// <summary>
        /// The congress of the bill
        /// <para>Supported: 105-117</para>
        /// <para>Bills before the 113th Congress (prior to 2013) have fewer attribute values than those from the 113th Congress onward.</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// The bill slug, for example hr4881
        /// </summary>
        public string BillId { get; set; } = "";

        internal override ProPublicaApiEndpoint Endpoint => new("{0}/bills/{1}.json", Congress, BillId);
        internal override HttpRequestMessage RequestMessage() => new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ApiServer + DataStore + Endpoint)
        };
    }
}