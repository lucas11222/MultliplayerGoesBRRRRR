using BepInEx;
using BepInEx.Logging;
using Steamworks;
using UnityEngine;

namespace MultliplayerGoesBRRRRRR;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger { get; private set; } = null!;

    public SteamId SteamID { get; private set; }

    private void Awake()
    {
        SteamClient.Init(1229490, true);

        SteamID = SteamClient.SteamId;
        
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded with SteamID {SteamID}");
    }
    
}