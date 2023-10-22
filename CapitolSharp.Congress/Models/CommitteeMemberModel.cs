using AutoMapper;
using CapitolSharp.Congress.Responses.Committee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class CommitteeMemberModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string api_uri { get; set; }
        public string party { get; set; }
        public string chamber { get; set; }
        public string side { get; set; }
        public int? rank_in_party { get; set; }
        public string state { get; set; }
        public object note { get; set; }
        public string begin_date { get; set; }
        public string end_date { get; set; }
        public string url { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<FormerMember, CommitteeMemberModel>();
                CreateMap<CurrentMember, CommitteeMemberModel>();
            }
        }
    }
}
