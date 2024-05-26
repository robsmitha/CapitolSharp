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
	/// Returns the list of text versions for a specified amendment from the 117th Congress onwards.
	/// </summary>
	public class AmendmentTextRequest : PagedApiRequest<AmendmentText.AmendmentTextResponse>
	{
		/// <summary>
		/// The congress number. This is endpoint is for the 117th Congress and onwards. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The type of amendment. Value can be hamdt or samdt.
		/// </summary>
		public AmendmentType AmendmentType { get; set; }

		/// <summary>
		/// The bill's assigned number. For example, the value can be 287.
		/// </summary>
		public int AmendmentNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/amendment/{0}/{1}/{2}/text", Congress, AmendmentType, AmendmentNumber);
	}
}
