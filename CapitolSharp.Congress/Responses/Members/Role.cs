﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Members
{
    public class Role
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public string title { get; set; }
        public string short_title { get; set; }
        public string state { get; set; }
        public string party { get; set; }
        public object leadership_role { get; set; }
        public string fec_candidate_id { get; set; }
        public string seniority { get; set; }
        public string district { get; set; }
        public bool? at_large { get; set; }
        public string ocd_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public object fax { get; set; }
        public object contact_form { get; set; }
        public int? bills_sponsored { get; set; }
        public int? bills_cosponsored { get; set; }
        public double? missed_votes_pct { get; set; }
        public double? votes_with_party_pct { get; set; }
        public List<MemberCommittee> committees { get; set; }
        public List<MemberCommittee> subcommittees { get; set; }
    }
}
