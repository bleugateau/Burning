using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Data.D2o.other;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Areas", true)]
  public class Area : IDataObject
  {
    public const string MODULE = "Areas";
    public int Id;
    public uint NameId;
    public int SuperAreaId;
    public bool ContainHouses;
    public bool ContainPaddocks;
    public Rectangle Bounds;
    public uint WorldmapId;
    public bool HasWorldMap;
  }
}
