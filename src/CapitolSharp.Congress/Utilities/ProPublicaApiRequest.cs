using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Utilities
{
    public abstract class ProPublicaApiRequest<T>
    {
        internal abstract ProPublicaApiEndpoint Endpoint { get; }
    }

    public abstract class ProPublicaApiRequestPaged<T> : ProPublicaApiRequest<T>
    {
        /// <summary>
        /// Pagination is available via an offset value using multiples of 20 for Responses that are not date-based.
        /// <para>Most votes, nomination and bill requests that return more than one object.</para>
        /// </summary>
        public int Offset { get; set; } = 0;
    }
}
