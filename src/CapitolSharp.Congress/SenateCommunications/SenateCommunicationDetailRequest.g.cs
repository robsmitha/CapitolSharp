//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Core.Enums;
using CapitolSharp.Congress.Core.Models;

namespace CapitolSharp.Congress.SenateCommunications
{
	/// <summary>
	/// Returns detailed information for a specified Senate communication.
	/// </summary>
	public class SenateCommunicationDetailRequest : JsonFormatApiRequest<SenateCommunicationDetail.SenateCommunicationDetailResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The type of communication. Value can be ec, pm, or pom.
		/// </summary>
		public string CommunicationType { get; set; }

		/// <summary>
		/// The communication's assigned number. For example, the value can be 2561.
		/// </summary>
		public int CommunicationNumber { get; set; }

		public override CongressApiEndpoint Endpoint => new("/senate-communication/{0}/{1}/{2}", Congress, CommunicationType, CommunicationNumber);
	}
}
