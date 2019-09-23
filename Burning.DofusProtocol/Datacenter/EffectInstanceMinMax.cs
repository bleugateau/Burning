using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceMinMax", true)]
  public class EffectInstanceMinMax : EffectInstance
  {
    public uint Min;
    public uint Max;
  }
}
