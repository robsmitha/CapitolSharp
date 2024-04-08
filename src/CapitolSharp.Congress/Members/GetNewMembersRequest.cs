using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetNewMembers;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get a list of the most recent new members of the current Congress
    /// </summary>
    public class GetNewMembersRequest : ProPublicaApiRequest<GetNewMembersResponse>
    {
        /// <summary>
        /// GET https://api.propublica.org/congress/v1/members/new.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("members/new.json");
    }
}
