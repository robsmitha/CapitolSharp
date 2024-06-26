//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.CommitteeMeetings
{
	/// <summary>
	/// Returns a list of committee meetings filtered by the specified congress and chamber.
	/// </summary>
	public class CommitteeMeetingCongressChamberRequest : PagedApiRequest<CommitteeMeetingCongressChamber.CommitteeMeetingCongressChamberResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 118.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The chamber name. Value can be house, senate, or nochamber.
		/// </summary>
		public Chamber Chamber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/committee-meeting/{0}/{1}", Congress, Chamber);
	}
}
