using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Votes
{
    public class SenateNominationVotesResult
    {
        public string total_votes { get; set; }
        public string offset { get; set; }
        public List<Vote> votes { get; set; }
    }
}
