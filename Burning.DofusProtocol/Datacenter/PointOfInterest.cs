using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("PointOfInterest", true)]
  public class PointOfInterest : IDataObject
  {
    public const string MODULE = "PointOfInterest";
    public uint Id;
    public uint NameId;
    public uint CategoryId;
  }
}
