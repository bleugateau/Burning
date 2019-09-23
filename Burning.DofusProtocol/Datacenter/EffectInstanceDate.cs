using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceDate", true)]
  public class EffectInstanceDate : EffectInstance
  {
    public uint Year;
    public uint Month;
    public uint Day;
    public uint Hour;
    public uint Minute;
  }
}
