using AutoMapper;
using CapitolSharp.Congress.Responses.Lobbying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class LobbyistModel
    {
        public string name { get; set; }
        public string covered_position { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Lobbyist, LobbyistModel>();
            }
        }
    }
}
