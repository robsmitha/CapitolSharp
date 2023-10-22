using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class MemberCosponsoredBillsModel
    {
        public List<BillModel> cosponsoredBills { get; set; }
        public MemberModel Member { get; set; }
        public MemberCosponsoredBillsModel(List<BillModel> cosponsoredBills, MemberModel member)
        {
            this.cosponsoredBills = cosponsoredBills;
            Member = member;
        }
    }
}
