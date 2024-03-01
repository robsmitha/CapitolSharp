using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Lobbying;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Stores
{
    public interface ILobbying
    {
        /// <summary>
        /// Get the most recent lobbying representation filings.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync(int offset = 0, CancellationToken cancellationToken = default);
    }
    public class Lobbying(ICongressApiClient client, IMapper mapper) : ILobbying
    {
        public async Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync(int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<LobbyingListResult>>>($"/lobbying/latest.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];

            var data = response.results.FirstOrDefault()?.lobbying_representations;
            return data != null
                ? mapper.Map<List<LobbyingRepresentationModel>>(data)
                : [];
        }
    }
}
