using AutoMapper;
using CapitolSharp.Congress.Responses.Committee;
using CapitolSharp.Congress.Responses.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class CommitteeModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string chamber { get; set; }
        public string url { get; set; }
        public string api_uri { get; set; }
        public string chair { get; set; }
        public string chair_id { get; set; }
        public string chair_party { get; set; }
        public string chair_state { get; set; }
        public string chair_uri { get; set; }
        public string ranking_member_id { get; set; }
        public List<SubcommitteeModel> subcommittees { get; set; }
        public List<CommitteeMemberModel> current_members { get; set; }
        public List<CommitteeMemberModel> former_members { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Committee, CommitteeModel>();
                CreateMap<CommitteeResult, CommitteeModel>();
            }
        }
    }
}
