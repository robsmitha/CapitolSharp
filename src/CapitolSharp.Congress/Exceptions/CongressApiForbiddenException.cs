using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Exceptions
{
    public class CongressApiForbiddenException : Exception
    {
        public CongressApiForbiddenException() : base("The request did not include a valid authorization header.")
        {

        }

        public CongressApiForbiddenException(string message) : base(message)
        {

        }
    }
}
