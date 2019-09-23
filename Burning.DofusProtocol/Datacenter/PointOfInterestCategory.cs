using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("PointOfInterestCategory", true)]
  public class PointOfInterestCategory : IDataObject
  {
    public const string MODULE = "PointOfInterestCategory";
    public uint Id;
    public uint ActionLabelId;
  }
}
