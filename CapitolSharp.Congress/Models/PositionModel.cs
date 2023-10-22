using AutoMapper;
using CapitolSharp.Congress.Responses.Votes;

namespace CapitolSharp.Congress.Models
{
    public class PositionModel
    {
        public string member_id { get; set; }
        public string name { get; set; }
        public string party { get; set; }
        public string state { get; set; }
        public string vote_position { get; set; }
        public double? dw_nominate { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Position, PositionModel>();
            }
        }
    }
}
