using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Statements;

namespace CapitolSharp.Congress.Stores
{
    public interface IStatements
    {
        Task<List<StatementModel>> GetRecentStatementsAsync();
        Task<List<StatementModel>> SearchStatementsAsync(string term);
    }

    public class Statements(ICongressApiClient client, IMapper mapper) : IStatements
    {
        public async Task<List<StatementModel>> GetRecentStatementsAsync()
        {
            var response = await client.SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json");
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }

        public async Task<List<StatementModel>> SearchStatementsAsync(string term)
        {
            var response = await client.SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}");
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }
    }
}
