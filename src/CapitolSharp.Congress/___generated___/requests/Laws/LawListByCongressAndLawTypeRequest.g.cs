//----------------------
// <auto-generated>
//     Generated using ApiContractor
// </auto-generated>
//----------------------
using System;
using CapitolSharp.Congress.Enums;
using CapitolSharp.Congress.Models;

namespace CapitolSharp.Congress.Laws
{
	/// <summary>
	/// Returns a list of laws filtered by specified congress and law type (public or private).
	/// </summary>
	public class LawListByCongressAndLawTypeRequest : PagedApiRequest<LawListByCongressAndLawType.LawListByCongressAndLawTypeResponse>
	{
		/// <summary>
		/// The congress number. For example, the value can be 117.
		/// </summary>
		public int Congress { get; set; }

		/// <summary>
		/// The law type. Values are either 'pub'or 'priv.'
		/// </summary>
		public string LawType { get; set; }

		public override CongressApiEndpoint Endpoint => new("/law/{0}/{1}", Congress, LawType);
	}
}
