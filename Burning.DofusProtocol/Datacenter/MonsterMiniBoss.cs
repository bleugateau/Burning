using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MonsterMiniBoss", true)]
  public class MonsterMiniBoss : IDataObject
  {
    public const string MODULE = "MonsterMiniBoss";
    public int Id;
    public int MonsterReplacingId;
  }
}
