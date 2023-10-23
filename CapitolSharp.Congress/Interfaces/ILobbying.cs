using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitolSharp.Congress.Interfaces
{
    public interface ILobbying
    {
        Task<List<LobbyingRepresentationModel>> GetRecentLobbyingRepresentationsAsync();
    }
}
