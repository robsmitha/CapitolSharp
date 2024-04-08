using CapitolSharp.Congress.Utilities;
using CapitolSharp.Congress.Members.GetQuarterlyOfficeExpensesForASpecifiedCategory;
using CapitolSharp.Congress.Enums;

namespace CapitolSharp.Congress.Members
{
    /// <summary>
    /// Use this request to get the amount spent by individual lawmakers in a specified category during a specified year and quarter by category.
    /// <para>The most recent quarter may not be available until several months after it ends.</para>
    /// </summary>
    public class GetQuarterlyOfficeExpensesForASpecifiedCategoryRequest : ProPublicaApiRequestPaged<GetQuarterlyOfficeExpensesForASpecifiedCategoryResponse>
    {
        /// <summary>
        /// Expense Category
        /// </summary>
        public ExpenseCategoryOption Category { get; set; }

        /// <summary>
        /// Year
        /// <para>2009-2019</para>
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Quarter
        /// <para>1, 2, 3, 4</para>
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// GET https://api.propublica.org/congress/v1/office_expenses/category/{category}/{year}/{quarter}.json
        /// </summary>
        internal override ProPublicaApiEndpoint Endpoint => new("office_expenses/category/{1}/{2}/{3}.json?offset={4}", Category, Year, Quarter, Offset);
    }
}
