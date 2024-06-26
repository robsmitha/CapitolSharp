//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Amendments
{
	/// <summary>
	/// Returns the list of cosponsors on a specified amendment.
	/// </summary>
	public class AmendmentCosponsorsRequest : PagedApiRequest<AmendmentCosponsors.AmendmentCosponsorsResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The type of amendment. Value can be hamdt, samdt, or suamdt.
		/// </summary>
		public AmendmentType AmendmentType { get; set; }

		/// <summary>
		/// The amendment's assigned number. For example, the value can be 2137.
		/// </summary>
		public int AmendmentNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/amendment/{0}/{1}/{2}/cosponsors", Congress, AmendmentType, AmendmentNumber);
	}
}
