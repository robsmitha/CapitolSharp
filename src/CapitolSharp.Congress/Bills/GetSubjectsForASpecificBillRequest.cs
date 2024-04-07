using CapitolSharp.Congress.Common;
using CapitolSharp.Congress.Bills.GetSubjectsForASpecificBill;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request type to get Library of Congress-assigned subjects about a particular bill.
    /// </summary>
    public class GetSubjectsForASpecificBillRequest : ProPublicaApiRequest<GetSubjectsForASpecificBillResponse>
    {
        /// <summary>
        /// The congress
        /// <para>Supported: 105-117</para>
        /// <para>Bills before the 113th Congress (prior to 2013) have fewer attribute values than those from the 113th Congress onward.</para>
        /// </summary>
        public int Congress { get; set; }

        /// <summary>
        /// The bill slug, for example hr4881
        /// </summary>
        public string BillId { get; set; } = "";

        internal override ProPublicaApiEndpoint Endpoint => new("{0}/bills/{1}/subjects.json", Congress, BillId);
    }
}
