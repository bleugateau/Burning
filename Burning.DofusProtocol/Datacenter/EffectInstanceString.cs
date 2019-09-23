using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceString", true)]
  public class EffectInstanceString : EffectInstance
  {
    public string Text;
  }
}
