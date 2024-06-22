using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Models
{
    public abstract class SortableApiRequest<T> : DateRangeApiRequest<T>
    {
        /// <summary>
        /// Sort by update date in Congress.gov. Value can be updateDate+asc or updateDate+desc.
        /// </summary>
        public string Sort { get; set; } = "";
        public SortByDirection Direction { get; set; } = SortByDirection.desc;

        public override Dictionary<string, string> QueryStringParameters => new (base.QueryStringParameters.Concat(new Dictionary<string, string>
        {
            { "sort", $"{Sort}+{Direction.ToString().ToLower()}" }
        }));
    }
}