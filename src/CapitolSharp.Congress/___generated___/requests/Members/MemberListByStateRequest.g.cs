//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Members
{
	/// <summary>
	/// Returns a list of members filtered by state.
	/// </summary>
	public class MemberListByStateRequest : JsonFormatApiRequest<MemberListByState.MemberListByStateResponse>
	{
		/// <summary>
		/// The two letter identifier for the state the member represents. For example, the value can be MI for Michigan.
		/// </summary>
		public StateCode StateCode { get; set; }

		public override CongressApiEndpoint Endpoint => new("/member/{0}", StateCode);
	}
}
