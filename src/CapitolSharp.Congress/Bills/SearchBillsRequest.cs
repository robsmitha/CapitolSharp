using CapitolSharp.Congress.Bills.SearchBills;
using CapitolSharp.Congress.Common;
using CapitolSharp.Congress.Options;

namespace CapitolSharp.Congress.Bills
{
    /// <summary>
    /// Use this request to search the title and full text of legislation by keyword to get the 20 most recent bills. 
    /// Searches cover House and Senate bills from the 113th Congress through the current Congress (117th).
    /// </summary>
    public class SearchBillsRequest : ProPublicaApiRequestPaged<SearchBillsResponse>
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

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/bills/search.json?query={query}&sort={sort}&dir={dir}&offset={&offset}
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("/bills/search.json?query={0}&sort={1}&dir={2}&offset={3}", 
            Query, Offset, Sort.Serialize(), SortDirection.Serialize());
    }
}
