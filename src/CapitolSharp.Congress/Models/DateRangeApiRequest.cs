using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public abstract class DateRangeApiRequest<T> : PagedApiRequest<T>
    {
        /// <summary>
        /// The starting timestamp to filter by update date.
        /// </summary>
        public DateTime? FromDateTime { get; set; }

        /// <summary>
        /// The ending timestamp to filter by update date.
        /// </summary>
        public DateTime? ToDateTime { get; set; }

        public override Dictionary<string, string> QueryStringParameters => new (base.QueryStringParameters.Concat(new Dictionary<string, string>
        {
            { "fromDateTime", FromDateTime?.ToString("yyyy-MM-ddTHH:mm:ssZ") },
            { "toDateTime", ToDateTime?.ToString("yyyy-MM-ddTHH:mm:ssZ") },
        }));
    }
}
