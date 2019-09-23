using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstance", true)]
  public class EffectInstance : IDataObject
  {
    public bool VisibleInTooltip = true;
    public bool VisibleInBuffUi = true;
    public bool VisibleInFightLog = true;
    public uint EffectUid;
    public uint EffectId;
    public int TargetId;
    public string TargetMask;
    public int Duration;
    public int Delay;
    public int Random;
    public int Group;
    public int Modificator;
    public bool Trigger;
    public string Triggers;
    public object ZoneSize;
    public uint ZoneShape;
    public object ZoneMinSize;
    public object ZoneEfficiencyPercent;
    public object ZoneMaxEfficiency;
    public object ZoneStopAtTarget;
    public int EffectElement;
    public string RawZone;
    public int SpellId;
    public int Order;
    public bool ForClientOnly;
    public int Dispellable;
  }
}
