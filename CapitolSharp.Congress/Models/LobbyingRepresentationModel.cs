using AutoMapper;
using CapitolSharp.Congress.Responses.Lobbying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class LobbyingRepresentationModel
    {
        public LobbyingClientModel lobbying_client { get; set; }
        public LobbyingRegistrantModel lobbying_registrant { get; set; }
        public string inhouse { get; set; }
        public string signed_date { get; set; }
        public string effective_date { get; set; }
        public string xml_filename { get; set; }
        public string id { get; set; }
        public List<string> specific_issues { get; set; }
        public string report_type { get; set; }
        public string report_year { get; set; }
        public string senate_id { get; set; }
        public string house_id { get; set; }
        public FilingModel latest_filing { get; set; }
        public List<FilingModel> filings { get; set; }
        public List<LobbyistModel> lobbyists { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<LobbyingRepresentation, LobbyingRepresentationModel>();
            }
        }
    }
}
