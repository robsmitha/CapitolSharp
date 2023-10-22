using CapitolSharp.Congress.Responses.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Bills
{
    public class UpcomingBills
    {
        public string date { get; set; }
        public List<UpcomingBill> bills { get; set; }
    }
}
