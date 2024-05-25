//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.Members
{
	/// <summary>
	/// Returns a list of congressional members.
	/// </summary>
	public class MemberListRequest : DateRangeApiRequest<MemberList.MemberListResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/member");
	}
}
