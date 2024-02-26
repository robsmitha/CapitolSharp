using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class ActionModel
    {
        public int id { get; set; }
        public string chamber { get; set; }
        public string action_type { get; set; }
        public string datetime { get; set; }
        public string description { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Responses.Bills.Action, ActionModel>();
            }
        }
    }
}
