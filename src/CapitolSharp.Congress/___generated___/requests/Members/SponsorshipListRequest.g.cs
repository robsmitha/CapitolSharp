//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Members
{
	/// <summary>
	/// Returns the list of legislation sponsored by a specified congressional member.
	/// </summary>
	public class SponsorshipListRequest : PagedApiRequest<SponsorshipList.SponsorshipListResponse>
	{
		/// <summary>
		/// The bioguide identifier for the congressional member. For example, the value can be L000174.
		/// </summary>
		public string BioguideId { get; set; }

		public override CongressApiEndpoint Endpoint => new("/member/{0}/sponsored-legislation", BioguideId);
	}
}
