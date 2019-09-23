using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceDuration", true)]
  public class EffectInstanceDuration : EffectInstance
  {
    public uint Days;
    public uint Hours;
    public uint Minutes;
  }
}
