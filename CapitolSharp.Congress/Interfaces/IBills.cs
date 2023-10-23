using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress.Interfaces
{
    public interface IBills
    {
        Task<BillModel> GetBillAsync(string congress, string billId);
        Task<List<BillModel>> GetUpcomingBillsAsync(string chamber);
    }
}
