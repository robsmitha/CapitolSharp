//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Nominations
{
	/// <summary>
	/// Returns a list of nominations sorted by date received from the President.
	/// </summary>
	public class NominationListRequest : DateRangeApiRequest<NominationList.NominationListResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/nomination");
	}
}
