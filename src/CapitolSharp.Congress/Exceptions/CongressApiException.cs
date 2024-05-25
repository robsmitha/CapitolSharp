using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Exceptions
{
    public class CongressApiException : Exception
    {
        public CongressApiException() : base("An unexpected API exception occurred.")
        {

        }

        public CongressApiException(string message) : base(message)
        {

        }
    }
}
