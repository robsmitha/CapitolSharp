using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Members
{
    public class CompareVotePositionsResult
    {
        public string first_member_id { get; set; }
        public string first_member_api_uri { get; set; }
        public string second_member_id { get; set; }
        public string second_member_api_uri { get; set; }
        public string congress { get; set; }
        public string chamber { get; set; }
        public int common_votes { get; set; }
        public int disagree_votes { get; set; }
        public decimal agree_percent { get; set; }
        public decimal disagree_percent { get; set; }
    }
}
