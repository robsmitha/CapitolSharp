//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.Amendments
{
	/// <summary>
	/// Returns a list of amendments sorted by date of latest action.
	/// </summary>
	public class AmendmentRequest : DateRangeApiRequest<Amendment.AmendmentResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/amendment");
	}
}
