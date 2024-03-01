using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Statements;

namespace CapitolSharp.Congress.Stores
{
    public interface IStatements
    {
        /// <summary>
        /// Get lists of recent statements published on congressional websites
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<StatementModel>> GetRecentStatementsAsync(int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get lists of statements published on congressional websites using a search term
        /// </summary>
        /// <param name="term"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<StatementModel>> SearchStatementsAsync(string term, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get lists of statements published on a specific member’s congressional website during a particular congress
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<StatementModel>> GetMemberStatementsAsync(string memberId, int offset = 0, CancellationToken cancellationToken = default);
    }

    public class Statements(ICongressApiClient client, IMapper mapper) : IStatements
    {
        public async Task<List<StatementModel>> GetRecentStatementsAsync(int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/latest.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }

        public async Task<List<StatementModel>> SearchStatementsAsync(string term, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<StatementResponse<IEnumerable<Statement>>>($"/statements/search.json?query={term}&offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }

        public async Task<List<StatementModel>> GetMemberStatementsAsync(string memberId, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<StatementResponse<List<Statement>>>($"members/{memberId}/statements.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results;
            return data != null
                ? mapper.Map<List<StatementModel>>(data)
                : [];
        }
    }
}
