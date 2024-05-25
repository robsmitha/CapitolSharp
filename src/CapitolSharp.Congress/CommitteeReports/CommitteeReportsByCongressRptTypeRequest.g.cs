//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.CommitteeReports
{
	/// <summary>
	/// Returns a list of committee reports filtered by the specified congress and report type.
	/// </summary>
	public class CommitteeReportsByCongressRptTypeRequest : DateRangeApiRequest<CommitteeReportsByCongressRptType.CommitteeReportsByCongressRptTypeResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 116.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The type of committee report. Value can be hrpt, srpt, or erpt.
		/// </summary>
		public string ReportType { get; set; }

		public override CongressApiEndpoint Endpoint => new("/committee-report/{0}/{1}", Congress, ReportType);
	}
}
