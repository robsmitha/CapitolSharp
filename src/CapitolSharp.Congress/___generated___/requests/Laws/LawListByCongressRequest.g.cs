//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Laws
{
	/// <summary>
	/// Returns a list of laws filtered by the specified congress.
	/// </summary>
	public class LawListByCongressRequest : PagedApiRequest<LawListByCongress.LawListByCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/law/{0}", Congress);
	}
}