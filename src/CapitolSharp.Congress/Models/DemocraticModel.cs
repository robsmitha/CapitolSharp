using AutoMapper;
using CapitolSharp.Congress.Responses.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class DemocraticModel
    {
        public int yes { get; set; }
        public int no { get; set; }
        public int present { get; set; }
        public int not_voting { get; set; }
        public string majority_position { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Democratic, DemocraticModel>();
            }
        }
    }
}
