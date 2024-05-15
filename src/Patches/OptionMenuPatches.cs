using HarmonyLib;
using Button = UnityEngine.UI.Button;

namespace FarmerLib.Patches;

[HarmonyPatch(typeof(OptionMenu))]
public class OptionMenuPatches
{
    /// <summary>
    /// Recalculate the category buttons when the category is changed.
    /// </summary>
    [HarmonyPrefix]
    [HarmonyPatch(nameof(OptionMenu.ChangeCategory))]
    public static void ChangeCategoryPrefix(ref string newCategory, OptionMenu __instance)
    {
        var This = __instance;
        This.allOptions = ResourceManager.GetAllOptions().OrderBy(o => o.importance).ToArray();
        
        var categories = This.allOptions.Select(o => o.category).Distinct().ToList();
        var categoriesToRemove = This.categoryButtons.Keys.Except(categories).ToList();
        var missingCategories = categories.Except(This.categoryButtons.Keys).ToList();

        foreach (var category in categoriesToRemove)
        {
            var btn = This.categoryButtons[category];
            This.categoryButtons.Remove(category);
            UnityEngine.Object.Destroy(btn);
        }
        foreach (var category in missingCategories)
        {
            var btn = UnityEngine.Object.Instantiate(This.coloredButtonPrefab, This.tabsContainer);

            btn.GetComponent<Button>().onClick.AddListener(() => This.ChangeCategory(category));
            btn.Text = category;

            This.categoryButtons[category] = btn;
        }

        if (!This.categoryButtons.ContainsKey(newCategory))
        {
            newCategory = categories.First();
        }

        if (!This.categoryButtons.ContainsKey(This.currentCategory))
        {
            This.currentCategory = newCategory;
        }
    }
}
