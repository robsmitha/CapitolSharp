using AutoMapper;
using CapitolSharp.Congress.Responses.Committee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class SubcommitteeModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string api_uri { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Subcommittee, SubcommitteeModel>();
            }
        }
    }
}
