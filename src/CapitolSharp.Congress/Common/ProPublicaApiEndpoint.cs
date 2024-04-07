using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Common
{
    public class ProPublicaApiEndpoint(string format, params object[] args)
    {
        public object[] _args = args;

        readonly string _format = format;

        public static implicit operator string(ProPublicaApiEndpoint d)
        {
            return d.ToString();
        }

        public override string ToString()
        {
            return string.Format(_format, _args);
        }
    }
}
