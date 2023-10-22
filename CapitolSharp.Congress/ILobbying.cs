using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress
{
    public interface ILobbying
    {
        Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync();
    }
}
