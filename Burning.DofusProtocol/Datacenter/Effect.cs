using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Effects", true)]
  public class Effect : IDataObject
  {
    public const string MODULE = "Effects";
    public int Id;
    public uint DescriptionId;
    public int IconId;
    public int Characteristic;
    public uint Category;
    public string Operator;
    public bool ShowInTooltip;
    public bool UseDice;
    public bool ForceMinMax;
    public bool Boost;
    public bool Active;
    public int OppositeId;
    public uint TheoreticalDescriptionId;
    public uint TheoreticalPattern;
    public bool ShowInSet;
    public int BonusType;
    public bool UseInFight;
    public uint EffectPriority;
    public int ElementId;
  }
}
