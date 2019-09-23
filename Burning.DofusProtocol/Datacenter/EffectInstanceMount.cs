using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceMount", true)]
  public class EffectInstanceMount : EffectInstance
  {
    public double Date;
    public uint ModelId;
    public uint MountId;
  }
}
