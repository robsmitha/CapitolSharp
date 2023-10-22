using AutoMapper;
using CapitolSharp.Congress.Responses.Lobbying;

namespace CapitolSharp.Congress.Models
{
    public class FilingModel
    {
        public string filing_date { get; set; }
        public string report_year { get; set; }
        public string report_type { get; set; }
        public string pdf_url { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Filing, FilingModel>();
            }
        }
    }
}
