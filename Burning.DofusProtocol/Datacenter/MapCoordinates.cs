using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MapCoordinates", true)]
  public class MapCoordinates : IDataObject
  {
    public const string MODULE = "MapCoordinates";
    public uint CompressedCoords;
    public List<double> MapIds;
  }
}
