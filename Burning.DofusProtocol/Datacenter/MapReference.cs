using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MapReferences", true)]
  public class MapReference : IDataObject
  {
    public const string MODULE = "MapReferences";
    public int Id;
    public double MapId;
    public int CellId;
  }
}
