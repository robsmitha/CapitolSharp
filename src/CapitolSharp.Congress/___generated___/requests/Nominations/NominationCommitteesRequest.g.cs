//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Nominations
{
	/// <summary>
	/// Returns the list of committees associated with a specified nomination.
	/// </summary>
	public class NominationCommitteesRequest : PagedApiRequest<NominationCommittees.NominationCommitteesResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The nomination's assigned number. For example, the value can be 2467.
		/// </summary>
		public int NominationNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/nomination/{0}/{1}/committees", Congress, NominationNumber);
	}
}
