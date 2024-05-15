## FarmerLib

A library aimed to make modding [TheFarmerWasReplaced](https://store.steampowered.com/app/2060160/The_Farmer_Was_Replaced) easier.

## 🚀 Getting Started
1. Have BepInEx installed
2. Clone the repository
3. Run `dotnet build`
4. Copy the `FarmerLib.dll` to the `Plugins` folder under `BepInEx/plugins`
5. Run the game

## 📝 Usage
```csharp
using FarmerLib.Resources;

namespace MyMod;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        OptionsManager.Instance.AddOption(new Models.CycleOption {
            Name = "My Option",
            Tooltip = "This is my option",
            Options = new() { "Value 1", "Value 2", "Value 3" }
        });
    }
}
```

## 📚 Resources
- [TheFarmerWasReplaced](https://store.steampowered.com/app/2060160/The_Farmer_Was_Replaced)
- [BepInEx](https://github.com/BepInEx/BepInEx)
