//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.Bills
{
	/// <summary>
	/// Returns the list of legislative subjects on a specified bill.
	/// </summary>
	public class BillSubjectsRequest : PagedApiRequest<BillSubjects.BillSubjectsResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The type of bill. Value can be hr, s, hjres, sjres, hconres, sconres, hres, or sres.
		/// </summary>
		public BillType BillType { get; set; }

		/// <summary>
		/// The bill's assigned number. For example, the value can be 3076.
		/// </summary>
		public int BillNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/bill/{0}/{1}/{2}/subjects", Congress, BillType, BillNumber);
	}
}
