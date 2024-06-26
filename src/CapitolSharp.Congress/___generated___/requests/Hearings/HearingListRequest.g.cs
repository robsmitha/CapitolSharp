//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Hearings
{
	/// <summary>
	/// Returns a list of hearings.
	/// </summary>
	public class HearingListRequest : PagedApiRequest<HearingList.HearingListResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/hearing");
	}
}
