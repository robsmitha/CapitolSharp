using AutoMapper;
using CapitolSharp.Congress.Responses.Members;

namespace CapitolSharp.Congress.Models
{
    public class MemberModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string short_title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string twitter_account { get; set; }
        public string facebook_account { get; set; }
        public string youtube_account { get; set; }
        public string rss_url { get; set; }
        public string most_recent_vote { get; set; }
        public string suffix { get; set; }
        public string date_of_birth { get; set; }
        public string gender { get; set; }
        public double? missed_votes_pct { get; set; }
        public double? votes_with_party_pct { get; set; }
        public List<RoleModel> roles { get; set; }
        public List<VoteModel> votes { get; set; }
        public List<BillModel> bills { get; set; }
        public List<BillModel> cosponsoredBills { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Member, MemberModel>()
                    .ForMember(m => m.party, opt => opt.MapFrom(src => src.current_party))
                    .ForMember(m => m.id, opt => opt.MapFrom(src => src.member_id));
                CreateMap<MemberListItem, MemberModel>();
            }
        }
    }
}
