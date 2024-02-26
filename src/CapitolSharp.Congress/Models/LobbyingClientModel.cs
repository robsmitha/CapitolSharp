using AutoMapper;
using CapitolSharp.Congress.Responses.Lobbying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class LobbyingClientModel
    {
        public string name { get; set; }
        public string general_description { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<LobbyingClient, LobbyingClientModel>();
            }
        }
    }
}
