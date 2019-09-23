using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MonsterSuperRaces", true)]
  public class MonsterSuperRace : IDataObject
  {
    public const string MODULE = "MonsterSuperRaces";
    public int Id;
    public uint NameId;
  }
}
