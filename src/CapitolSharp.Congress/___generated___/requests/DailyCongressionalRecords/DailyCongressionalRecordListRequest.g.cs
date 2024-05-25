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
	/// Returns a list of daily congressional record issues sorted by most recent.
	/// </summary>
	public class DailyCongressionalRecordListRequest : PagedApiRequest<DailyCongressionalRecordList.DailyCongressionalRecordListResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/daily-congressional-record");
	}
}