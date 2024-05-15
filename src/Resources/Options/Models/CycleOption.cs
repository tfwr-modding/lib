namespace FarmerLib.Resources.Options.Models;


public class CycleOption: Option
{
    public new UIType Type = UIType.Cycle;
    public List<string> Options = new();
    
    public new void Setup(OptionSO scriptableObject)
    {
        base.Setup(scriptableObject);
        (scriptableObject as CycleOptionSO)!.options = Options;
    }
}
