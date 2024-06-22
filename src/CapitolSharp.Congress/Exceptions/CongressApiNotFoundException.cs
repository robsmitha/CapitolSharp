using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Exceptions
{
    public class CongressApiNotFoundException : Exception
    {
        public CongressApiNotFoundException() : base("The specified record(s) could not be found.")
        {

        }

        public CongressApiNotFoundException(string message) : base(message)
        {

        }
    }
}
