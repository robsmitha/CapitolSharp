//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Bills
{
	/// <summary>
	/// Returns a list of bills filtered by the specified congress, sorted by date of latest action.
	/// </summary>
	public class BillListByCongressRequest : SortableApiRequest<BillListByCongress.BillListByCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/bill/{0}", Congress);
	}
}