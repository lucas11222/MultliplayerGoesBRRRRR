using System.Threading.Tasks;
using BepInEx.Logging;
using Steamworks;
using Steamworks.Data;

namespace MultliplayerGoesBRRRRRR.Networking
{
    public class NetworkManager
    {
        public Lobby CurrentLobby;

        public async Task CreateLobby()
        {
            Lobby? lobby = await SteamMatchmaking.CreateLobbyAsync(2);

            if (lobby.HasValue)
            {
                CurrentLobby = lobby.Value;

                CurrentLobby.SetData("LobbyName", "name");
                Plugin.Logger.LogInfo(CurrentLobby.Id.ToString());
            }
        }

        public async Task JoinLobby(ulong lobbyId)
        {
            Lobby? lobby = await SteamMatchmaking.JoinLobbyAsync(lobbyId);

            if (lobby.HasValue)
            {
                CurrentLobby = lobby.Value;

                Plugin.Logger.LogInfo(CurrentLobby.GetData("LobbyName"));
            }
        }
    }
}