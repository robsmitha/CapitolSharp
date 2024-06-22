using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Exceptions
{
    public class CongressApiBadRequestException : Exception
    {
        public CongressApiBadRequestException() : base("The request is improperly formed.")
        {

        }

        public CongressApiBadRequestException(string message) : base(message)
        {

        }
    }
}
