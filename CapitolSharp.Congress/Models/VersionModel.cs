using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public class VersionModel
    {
        public string status { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string congressdotgov_url { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Version, VersionModel>();
            }
        }
    }
}
