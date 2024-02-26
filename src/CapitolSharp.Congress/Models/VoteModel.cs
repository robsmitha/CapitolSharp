using AutoMapper;
using BillsVote = CapitolSharp.Congress.Responses.Bills.Vote;
using VotesVote = CapitolSharp.Congress.Responses.Votes.Vote;

namespace CapitolSharp.Congress.Models
{
    public class VoteModel
    {
        public string member_id { get; set; }
        public string chamber { get; set; }
        public string congress { get; set; }
        public string session { get; set; }
        public string roll_call { get; set; }
        public string vote_uri { get; set; }
        public BillModel bill { get; set; }
        public string description { get; set; }
        public string question { get; set; }
        public string result { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public TotalModel total { get; set; }
        public AmendmentModel amendment { get; set; }
        public DemocraticModel democratic { get; set; }
        public RepublicanModel republican { get; set; }
        public IndependentModel independent { get; set; }
        public List<PositionModel> positions { get; set; }
        public string position { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<BillsVote, VoteModel>();
                CreateMap<VotesVote, VoteModel>();
            }
        }
    }
}
