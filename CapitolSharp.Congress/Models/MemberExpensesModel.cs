using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class MemberExpensesModel
    {
        public MemberModel Member { get; set; }
        public List<ExpensesModel> Expenses { get; set; }
        public MemberExpensesModel(List<ExpensesModel> expenses, MemberModel member)
        {
            Member = member;
            Expenses = expenses;
        }
    }
}
