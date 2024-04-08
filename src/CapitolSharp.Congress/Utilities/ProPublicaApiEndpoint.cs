using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Utilities
{
    public class ProPublicaApiEndpoint(string format, params object[] args)
    {
        internal const string ApiServer = "https://api.propublica.org";

        internal const string CongressDataStore = ApiServer + "/congress/v1";

        public object[] _args = args;

        readonly string _format = format;

        public static implicit operator string(ProPublicaApiEndpoint d)
        {
            return d.ToString();
        }

        public override string ToString()
        {
            return CongressDataStore + string.Format(_format, _args);
        }
    }
}
