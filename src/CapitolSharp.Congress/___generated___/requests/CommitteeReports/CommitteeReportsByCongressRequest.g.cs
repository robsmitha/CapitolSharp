//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.CommitteeReports
{
	/// <summary>
	/// Returns a list of committee reports filtered by the specified congress.
	/// </summary>
	public class CommitteeReportsByCongressRequest : DateRangeApiRequest<CommitteeReportsByCongress.CommitteeReportsByCongressResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 116.
		/// </summary>
		public int Congress { get; set; }

		public override CongressApiEndpoint Endpoint => new("/committee-report/{0}", Congress);
	}
}
