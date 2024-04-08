using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Utilities
{
    public class ProPublicaApiException : Exception
    {
        public ProPublicaApiException() : base("An unexpected ProPublica API exception occurred.")
        {

        }

        public ProPublicaApiException(string message) : base(message)
        {

        }
    }
}
