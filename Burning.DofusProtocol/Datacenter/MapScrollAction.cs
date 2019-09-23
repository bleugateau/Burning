using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MapScrollActions", true)]
  public class MapScrollAction : IDataObject
  {
    public const string MODULE = "MapScrollActions";
    public double Id;
    public bool RightExists;
    public bool BottomExists;
    public bool LeftExists;
    public bool TopExists;
    public double RightMapId;
    public double BottomMapId;
    public double LeftMapId;
    public double TopMapId;
  }
}
