//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.DailyCongressionalRecords
{
	/// <summary>
	/// Returns a list of daily Congressional Records filtered by the specified volume number and specified issue number.
	/// </summary>
	public class DailyCongressionalRecordListByVolumeAndIssueRequest : PagedApiRequest<DailyCongressionalRecordListByVolumeAndIssue.DailyCongressionalRecordListByVolumeAndIssueResponse>
	{
		/// <summary>
		/// The specified volume of the daily Congressional record, for example 166.
		/// </summary>
		public string VolumeNumber { get; set; }

		/// <summary>
		/// The specified issue of the daily Congressional record, for example 153.
		/// </summary>
		public string IssueNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/daily-congressional-record/{0}/{1}", VolumeNumber, IssueNumber);
	}
}
