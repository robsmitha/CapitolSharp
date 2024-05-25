using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Models
{
    public abstract class PagedApiRequest<T> : JsonFormatApiRequest<T>
    {
        /// <summary>
        /// The starting record returned. 0 is the first record.
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// The number of records returned. The maximum limit is 250.
        /// </summary>
        public int Limit { get; set; } = 20;

        public override Dictionary<string, string> QueryStringParameters => new(base.QueryStringParameters.Concat(new Dictionary<string, string>
        {
            { "offset", Offset.ToString() },
            { "limit", Limit.ToString() },
        }));
    }
}
