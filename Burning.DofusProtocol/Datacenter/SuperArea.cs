using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SuperAreas", true)]
  public class SuperArea : IDataObject
  {
    public const string MODULE = "SuperAreas";
    public int Id;
    public uint NameId;
    public uint WorldmapId;
    public bool HasWorldMap;
  }
}
