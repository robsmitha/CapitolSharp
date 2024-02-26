using AutoMapper;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Models
{
    public class SubjectModel
    {
        public string api_uri { get; set; }
        public string name { get; set; }
        public string slug { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Subject, SubjectModel>();
            }
        }
    }
}
