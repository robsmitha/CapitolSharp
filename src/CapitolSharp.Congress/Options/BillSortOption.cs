using CapitolSharp.Congress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Options
{
    public enum BillSortOption
    {
        /// <summary>
        /// Order by introduced_date
        /// </summary>
        [SerializedOption("introduced")]
        Introduced,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("updated")]
        Updated,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("active")]
        Active,

        /// <summary>
        /// Order by latest_major_action_date
        /// </summary>
        [SerializedOption("passed")]
        Passed,

        /// <summary>
        /// Order by enacted
        /// </summary>
        [SerializedOption("enacted")]
        Enacted,

        /// <summary>
        /// Order by vetoed
        /// </summary>
        [SerializedOption("vetoed")]
        Vetoed,
    }
}
