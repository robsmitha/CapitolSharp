//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.SenateCommunications
{
	/// <summary>
	/// Returns a list of Senate communications filtered by the specified congress.
	/// </summary>
	public class SenateCommunicationCongressRequest : PagedApiRequest<SenateCommunicationCongress.SenateCommunicationCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/senate-communication/{0}", Congress);
	}
}
