//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.Treaties
{
	/// <summary>
	/// Returns detailed information for a specified partitioned treaty.
	/// </summary>
	public class TreatyDetailsRequest : JsonFormatApiRequest<TreatyDetails.TreatyDetailsResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 114.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The treaty's assigned number. For example, the value can be 13.
		/// </summary>
		public int TreatyNumber { get; set; }

		/// <summary>
		/// The treaty's partition letter value. For example, the value can be A.
		/// </summary>
		public string TreatySuffix { get; set; }

		public override CongressApiEndpoint Endpoint => new("/treaty/{0}/{1}/{2}", Congress, TreatyNumber, TreatySuffix);
	}
}
