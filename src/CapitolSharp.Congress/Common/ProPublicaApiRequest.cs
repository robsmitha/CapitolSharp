using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Common
{
    public abstract class ProPublicaApiRequest<T>
    {
        internal const string ApiServer = "https://api.propublica.org";

        internal const string DataStore = "/congress/v1";
        internal abstract HttpRequestMessage RequestMessage();
        internal abstract ProPublicaApiEndpoint Endpoint { get; }

        /// <summary>
        /// Pagination is available via an offset value using multiples of 20 for Responses that are not date-based.
        /// <para>Most votes, nomination and bill requests that return more than one object.</para>
        /// </summary>
        public int Offset { get; set; } = 0;
    }
}
