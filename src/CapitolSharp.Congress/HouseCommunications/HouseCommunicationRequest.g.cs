//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.HouseCommunications
{
	/// <summary>
	/// Returns a list of House communications.
	/// </summary>
	public class HouseCommunicationRequest : PagedApiRequest<HouseCommunication.HouseCommunicationResponse>
	{
		public override CongressApiEndpoint Endpoint => new("/house-communication");
	}
}
