using CapitolSharp.Congress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Options
{
    public enum SearchBillsSortOption
    {
        [SerializedOption("date")]
        Date,

        [SerializedOption("_score")]
        Score
    }
}
