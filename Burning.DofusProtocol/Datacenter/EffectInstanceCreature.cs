using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EffectInstanceCreature", true)]
  public class EffectInstanceCreature : EffectInstance
  {
    public uint MonsterFamilyId;
  }
}
