using CapitolSharp.Congress.Common;
using CapitolSharp.Congress.Bills.GetASpecificBillSubject;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request type to search for bill subjects that contain a specified term.
    /// </summary>
    public class GetASpecificBillSubjectRequest : ProPublicaApiRequest<GetASpecificBillSubjectResponse>
    {
        /// <summary>
        /// A word or phrase to search
        /// </summary>
        public string Query { get; set; } = "";

        internal override ProPublicaApiEndpoint Endpoint => new("/bills/subjects/search.json?query={0}&offset={1}", Query, Offset);
    }
}
