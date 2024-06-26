//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.CommitteePrints
{
	/// <summary>
	/// Returns a list of committee prints filtered by the specified congress.
	/// </summary>
	public class CommitteePrintsByCongressRequest : DateRangeApiRequest<CommitteePrintsByCongress.CommitteePrintsByCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/committee-print/{0}", Congress);
	}
}
