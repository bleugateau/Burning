using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CreatureBonesTypes", true)]
  public class CreatureBoneType : IDataObject
  {
    public const string MODULE = "CreatureBonesTypes";
    public int Id;
    public int CreatureBoneId;
  }
}
