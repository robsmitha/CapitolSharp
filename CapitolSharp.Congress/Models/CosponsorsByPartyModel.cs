using AutoMapper;
using CapitolSharp.Congress.Responses.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class CosponsorsByPartyModel
    {
        public int? R { get; set; }
        public int? D { get; set; }
        public int? I { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CosponsorsByParty, CosponsorsByPartyModel>();
            }
        }
    }
}
