//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.Committees
{
	/// <summary>
	/// Returns the list of House communications associated with a specified congressional committee.
	/// </summary>
	public class HouseCommunicationsByCommitteeRequest : PagedApiRequest<HouseCommunicationsByCommittee.HouseCommunicationsByCommitteeResponse>
	{
		/// <summary>
		/// The chamber name. Value will be house.
		/// </summary>
		public string Chamber { get; set; }

		/// <summary>
		/// The committee code for the committee. For example, the value can be hspw00.
		/// </summary>
		public string CommitteeCode { get; set; }

		public override CongressApiEndpoint Endpoint => new("/committee/{0}/{1}/house-communication", Chamber, CommitteeCode);
	}
}
