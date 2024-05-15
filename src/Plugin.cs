using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace FarmerLib;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; private set; } = null!;
    public static ManualLogSource Log { get; private set; } = null!;
    
    private readonly Harmony harmony = new(MyPluginInfo.PLUGIN_GUID);
    
    private void Awake()
    {
        Instance = this;
        Log = Logger;
        
        harmony.PatchAll();
    }
}
