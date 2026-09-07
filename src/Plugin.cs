using BepInEx;
using BepInEx.Logging;
using Steamworks;
using UnityEngine;
using MultliplayerGoesBRRRRRR.Networking;
namespace MultliplayerGoesBRRRRRR;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger { get; private set; } = null!;

    public readonly NetworkManager networkManager = new();

    public SteamId SteamID { get; private set; }

    private void Awake()
    {
        SteamClient.Init(1229490, true);

        SteamID = SteamClient.SteamId;
        
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded with SteamID {SteamID}");
        networkManager.JoinLobby(109775244839209818);
    }

    private void OnApplicationQuit()
    {
        SteamClient.Shutdown();
    }
}
