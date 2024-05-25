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
	/// Returns the list of members specified by Congress
	/// </summary>
	public class CongressListRequest : PagedApiRequest<CongressList.CongressListResponse>
	{
		/// <summary>
		/// The congress for the congressional member. For example, the value can be 118.
		/// </summary>
		public string Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/member/0/{0}", Congress);
	}
}