namespace FarmerLib.Resources.Options.Models;


public abstract class Option
{
    public string Name;
    public UIType Type = UIType.Cycle;
    public string Tooltip;
    public string DefaultValue = "";
    public float Importance = -1.0f;
    public string Category = "mods";

    public void Setup(OptionSO scriptableObject)
    {
        scriptableObject.optionName = Name;
        scriptableObject.tooltip = Tooltip;
        scriptableObject.defaultValue = DefaultValue;
        scriptableObject.importance = Importance;
        scriptableObject.category = Category;
    }
}
