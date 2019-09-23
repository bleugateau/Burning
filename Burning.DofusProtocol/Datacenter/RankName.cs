using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("RankNames", true)]
  public class RankName : IDataObject
  {
    public const string MODULE = "RankNames";
    public int Id;
    public uint NameId;
    public int Order;
  }
}
