using CapitolSharp.Congress.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Enums
{
    public enum BillSortOption
    {
        /// <summary>
        /// Order by introduced_date
        /// </summary>
        Introduced,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        Updated,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        Active,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        Passed,

        /// <summary>
        /// Order by enacted
        /// </summary>
        Enacted,

        /// <summary>
        /// Order by vetoed
        /// </summary>
        Vetoed,
    }
}
