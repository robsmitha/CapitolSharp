﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Responses.Bills
{
    public class BillsResponse<TResult> : Response<TResult>
    {
        public string subject { get; set; }
    }
}
