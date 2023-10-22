using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Lobbying
{
    public class LobbyingListResult
    {
        public int num_results { get; set; }
        public int offset { get; set; }
        public string query { get; set; }
        public List<LobbyingRepresentation> lobbying_representations { get; set; }
    }
}
