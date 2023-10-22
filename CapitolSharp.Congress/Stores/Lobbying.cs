using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Lobbying;
using CapitolSharp.Congress.Responses;
using CapitolSharp.DataStore;

namespace CapitolSharp.Congress.Stores
{
    public class Lobbying : DataStoreAccessor, ILobbying
    {
        public Lobbying(IHttpClientFactory httpClientFactory, IMapper mapper)
            : base(httpClientFactory, mapper)
        {

        }

        public async Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync()
        {
            var response = await SendAsync<Response<IEnumerable<LobbyingListResult>>>($"lobbying/latest.json");
            if (response?.results == null) return new List<LobbyingRepresentationModel>();

            var data = response.results.FirstOrDefault()?.lobbying_representations;
            return data != null
                ? _mapper.Map<List<LobbyingRepresentationModel>>(data)
                : new List<LobbyingRepresentationModel>();
        }
    }
}
