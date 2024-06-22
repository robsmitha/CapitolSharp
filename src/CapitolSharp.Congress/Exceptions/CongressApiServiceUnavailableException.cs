using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Exceptions
{
    public class CongressApiServiceUnavailableException :  Exception
    {
        public CongressApiServiceUnavailableException() : base("Service Unavailable – The service is currently not working. Please try again later.")
        {

        }

        public CongressApiServiceUnavailableException(string message) : base(message)
        {

        }
    }
}
