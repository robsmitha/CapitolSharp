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
	/// Returns a list of amendments filtered by the specified congress, sorted by date of latest action.
	/// </summary>
	public class AmendmentListByCongressRequest : DateRangeApiRequest<AmendmentListByCongress.AmendmentListByCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/amendment/{0}", Congress);
	}
}
