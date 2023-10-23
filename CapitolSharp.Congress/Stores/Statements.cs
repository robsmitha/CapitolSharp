using AutoMapper;
using CapitolSharp.Congress.Interfaces;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Statements;

namespace CapitolSharp.Congress.Stores
{
    public class Statements : DataStoreAccessor, IStatements
    {
        public Statements(string apiKey, IMapper mapper)
            : base(apiKey, mapper)
        {

        }

        public async Task<List<StatementModel>> GetRecentStatementsAsync()
        {
            var response = await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json");
            if (response?.results == null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }

        public async Task<List<StatementModel>> SearchStatementsAsync(string term)
        {
            var response = await SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}");
            if (response?.results == null) return new List<StatementModel>();
            var data = response.results;
            return _mapper.Map<List<StatementModel>>(data);
        }
    }
}
