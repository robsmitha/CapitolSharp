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
	/// Returns detailed information for a specified hearing.
	/// </summary>
	public class HearingDetailRequest : JsonFormatApiRequest<HearingDetail.HearingDetailResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 116.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The chamber name. Value can be house, senate, or nochamber.
		/// </summary>
		public string Chamber { get; set; }

		/// <summary>
		/// The jacket number for the hearing. For example, the value can be 41365.
		/// </summary>
		public int JacketNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/hearing/{0}/{1}/{2}", Congress, Chamber, JacketNumber);
	}
}