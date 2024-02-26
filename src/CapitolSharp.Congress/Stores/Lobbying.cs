﻿using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Lobbying;
using CapitolSharp.Congress.Responses;

namespace CapitolSharp.Congress.Stores
{
    public interface ILobbying
    {
        Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync();
    }
    public class Lobbying(ICongressApiClient client, IMapper mapper) : ILobbying
    {
        public async Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync()
        {
            var response = await client.SendAsync<Response<IEnumerable<LobbyingListResult>>>($"lobbying/latest.json");
            if (response?.results == null) return [];

            var data = response.results.FirstOrDefault()?.lobbying_representations;
            return data != null
                ? mapper.Map<List<LobbyingRepresentationModel>>(data)
                : [];
        }
    }
}
