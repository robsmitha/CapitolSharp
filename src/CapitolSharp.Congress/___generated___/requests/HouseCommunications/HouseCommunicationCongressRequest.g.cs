//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.HouseCommunications
{
	/// <summary>
	/// Returns a list of House communications filtered by the specified congress.
	/// </summary>
	public class HouseCommunicationCongressRequest : PagedApiRequest<HouseCommunicationCongress.HouseCommunicationCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/house-communication/{0}", Congress);
	}
}
