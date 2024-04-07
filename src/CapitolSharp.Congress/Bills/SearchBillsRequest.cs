using CapitolSharp.Congress.Bills.SearchBills;
using CapitolSharp.Congress.Common;

namespace CapitolSharp.Congress
{
    public class SearchBillsRequest : ProPublicaApiRequest<SearchBillsResponse>
    {
        /// <summary>
        /// The query to search the title and full text of legislation by keyword to get the 20 most recent bills.
        /// 
        /// <para>If multiple words are given (e.g. query=health care) the search is treated as multiple keywords using the OR operator. 
        /// Quoting the words (e.g. query="health care") makes it a phrase search.</para>
        /// </summary>
        public string Query { get; set; } = "";

        /// <summary>
        /// Search results can be sorted by date (the default) or by relevance.
        /// </summary>
        public SearchBillsSortOption Sort { get; set; } = SearchBillsSortOption.Date;

        /// <summary>
        /// Search results can be sorted in ascending or descending order
        /// </summary>
        public SortDirectionOption SortDirection { get; set; } = SortDirectionOption.Descending;

        internal override ProPublicaApiEndpoint Endpoint => new("/bills/search.json?query={0}&offset={1}&sort={2}&dir={3}", 
            Query, Offset, Sort.Serialize(), SortDirection.Serialize());

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/bills/search.json?query={query}&offset={&offset}&sort={sort}&dir={dir}
        /// </summary>
        /// <returns></returns>
        internal override HttpRequestMessage RequestMessage() => new()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ApiServer + DataStore + Endpoint)
        };
    }

    public enum SearchBillsSortOption
    {
        [SerializedOption("date")]
        Date,

        [SerializedOption("_score")]
        Score
    }
}
