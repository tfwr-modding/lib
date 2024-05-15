using FarmerLib.Resources.Options.Models;
using FarmerLib.utils;
using UnityEngine;

namespace FarmerLib.Resources;


public class OptionsManager: Singleton<OptionsManager>
{
    private List<Option> Options = new();
    private Dictionary<UIType, OptionUI> UITypes = new();

    private string optionHash = "";
    private OptionSO[] cachedOptions = Array.Empty<OptionSO>();

    private void InitTypes(OptionSO[] prefabs)
    {
        if (UITypes.Count > 0) return;
        
        foreach (var optionSo in prefabs)
        {
            UIType? uiType = optionSo.optionUI.GetType().Name switch
            {
                "SliderOptionUI" => UIType.Slider,
                "CycleOptionUI" => UIType.Cycle,
                "KeyBindOptionUI" => UIType.KeyBind,
                _ => null,
            };
            
            if (uiType is null || UITypes.ContainsKey(uiType.Value)) continue;
            UITypes[uiType.Value] = optionSo.optionUI;
        }
    }

    internal OptionSO[] ModifyOptions(OptionSO[] options)
    {
        this.InitTypes(options);
        
        var hash = string.Join(",", Options.Select(opt => opt.Name));
        if (hash == optionHash) return options.Concat(cachedOptions).ToArray();
        
        // repopulate options
        optionHash = hash;
        cachedOptions = Options.Select<Option, OptionSO>(opt =>
        {
            // TODO: Add the other types.
            switch (opt.GetType().Name)
            {
                case "CycleOption":
                {
                    var cycleOpt = (CycleOption)opt;
                    var so = ScriptableObject.CreateInstance<CycleOptionSO>();
                    
                    so.optionUI = UnityEngine.Object.Instantiate(UITypes[cycleOpt.Type]);
                    cycleOpt.Setup(so);

                    return so;
                }
                    
                default: throw new NotImplementedException();
            }
        }).ToArray();

        return options.Concat(cachedOptions).ToArray();
    }
    
    public void AddOption(Option option)
    {
        Options.Add(option);
    }
}
