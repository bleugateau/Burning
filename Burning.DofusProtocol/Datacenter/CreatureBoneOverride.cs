using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CreatureBonesOverrides", true)]
  public class CreatureBoneOverride : IDataObject
  {
    public const string MODULE = "CreatureBonesOverrides";
    public int BoneId;
    public int CreatureBoneId;
  }
}
