using CapitolSharp.Congress.Common;
using CapitolSharp.Congress.Bills.GetRecentBillsByASpecificMember;

namespace CapitolSharp.Congress.Bills
{
    public enum GetRecentBillsByASpecificMemberTypeOption
    {
        /// <summary>
        /// Order by introduced_date
        /// </summary>
        [SerializedOption("introduced")]
        Introduced,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("updated")]
        Updated,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("active")]
        Active,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("passed")]
        Passed,

        /// <summary>
        /// Order by enacted
        /// </summary>
        [SerializedOption("enacted")]
        Enacted,

        /// <summary>
        /// Order by vetoed
        /// </summary>
        [SerializedOption("vetoed")]
        Vetoed,

    }

    /// <summary>
    /// Get the 20 bills most recently introduced or updated by a particular member.
    /// <para>Results can include more than one Congress.</para>
    /// </summary>
    public class GetRecentBillsByASpecificMemberRequest : ProPublicaApiRequest<GetRecentBillsByASpecificMemberResponse>
    {
        /// <summary>
        /// The ID of the member to retrieve
        /// </summary>
        public string MemberId { get; set; } = "";

        /// <summary>
        /// The order of the results
        /// </summary>
        public GetRecentBillsByASpecificMemberTypeOption Type { get; set; }

        internal override ProPublicaApiEndpoint Endpoint => new("/members/{0}/bills/{1}.json", MemberId, Type.Serialize());

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/{member-id}/bills/{type}.json
        /// </summary>
        internal override HttpRequestMessage RequestMessage() => new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ApiServer + DataStore + Endpoint)
        };
    }
}
