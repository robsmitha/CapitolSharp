﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Members
{
    public class MemberListItem
    {
        public string id { get; set; }
        public string title { get; set; }
        public string short_title { get; set; }
        public string api_uri { get; set; }
        public string first_name { get; set; }
        public object middle_name { get; set; }
        public string last_name { get; set; }
        public object suffix { get; set; }
        public string date_of_birth { get; set; }
        public string gender { get; set; }
        public string party { get; set; }
        public object leadership_role { get; set; }
        public string twitter_account { get; set; }
        public string facebook_account { get; set; }
        public string youtube_account { get; set; }
        public string govtrack_id { get; set; }
        public string cspan_id { get; set; }
        public string votesmart_id { get; set; }
        public string icpsr_id { get; set; }
        public string crp_id { get; set; }
        public string google_entity_id { get; set; }
        public string fec_candidate_id { get; set; }
        public string url { get; set; }
        public string rss_url { get; set; }
        public string contact_form { get; set; }
        public bool in_office { get; set; }
        public double? dw_nominate { get; set; }
        public object ideal_point { get; set; }
        public string seniority { get; set; }
        public string next_election { get; set; }
        public int? total_votes { get; set; }
        public int? missed_votes { get; set; }
        public int? total_present { get; set; }
        public string last_updated { get; set; }
        public string ocd_id { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string state { get; set; }
        public string senate_class { get; set; }
        public string state_rank { get; set; }
        public string lis_id { get; set; }
        public double? missed_votes_pct { get; set; }
        public double? votes_with_party_pct { get; set; }

        public string role { get; set; }
        public string district { get; set; }
        public string begin_date { get; set; }
        public string end_date { get; set; }
        public string status { get; set; }
        public string note { get; set; }
    }
}
