using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceInteger", true)]
  public class EffectInstanceInteger : EffectInstance
  {
    public int Value;
    public new int SpellId;
    public new int Dispellable;
    public new bool ForClientOnly;
  }
}
