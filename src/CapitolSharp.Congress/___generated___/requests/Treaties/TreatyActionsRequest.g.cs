//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Treaties
{
	/// <summary>
	/// Returns the list of actions on a specified partitioned treaty.
	/// </summary>
	public class TreatyActionsRequest : PagedApiRequest<TreatyActions.TreatyActionsResponse>
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

		public override CongressApiEndpoint Endpoint => new("/treaty/{0}/{1}/{2}/actions", Congress, TreatyNumber, TreatySuffix);
	}
}