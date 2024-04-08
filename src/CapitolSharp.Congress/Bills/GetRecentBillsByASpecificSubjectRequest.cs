using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Bills.GetRecentBillsByASpecificSubject;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request type to get the 20 most recently updated bills for a specific legislative subject. Results can include more than one Congress.
    /// </summary>
    public class GetRecentBillsByASpecificSubjectRequest : ProPublicaApiRequestPaged<GetRecentBillsByASpecificSubjectResponse>
    {
        /// <summary>
        /// A slug version of a legislative subject (displayed as url_name in subject responses).
        /// </summary>
        public string Subject { get; set; } = "";

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/bills/subjects/{subject}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("/bills/subjects/{0}.json?offset={1}", Subject, Offset);
    }
}
