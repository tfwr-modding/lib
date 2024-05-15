using FarmerLib.Resources;
using FarmerLib.utils;
using HarmonyLib;

namespace FarmerLib.Patches;

[HarmonyPatch(typeof(ResourceManager))]
public class ResourceManagerPatches
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ResourceManager.GetAllOptions))]
    public static void GetAllOptionsPostfix(ref OptionSO[] __result)
    {
        __result = Singleton<OptionsManager>.Instance.ModifyOptions(__result);
    }
}
