using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress
{
    public interface IStatements
    {
        Task<List<StatementModel>> GetRecentStatementsAsync();
        Task<List<StatementModel>> SearchStatementsAsync(string term);
    }
}
