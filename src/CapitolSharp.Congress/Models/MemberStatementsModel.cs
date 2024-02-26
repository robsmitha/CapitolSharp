using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class MemberStatementsModel
    {
        public MemberModel Member { get; set; }
        public List<StatementModel> Statements { get; set; }
        public MemberStatementsModel(List<StatementModel> statements, MemberModel member)
        {
            Statements = statements;
            Member = member;
        }
    }
}
