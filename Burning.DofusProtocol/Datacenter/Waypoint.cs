using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Waypoints", true)]
  public class Waypoint : IDataObject
  {
    public const string MODULE = "Waypoints";
    public uint Id;
    public double MapId;
    public uint SubAreaId;
    public bool Activated;
  }
}
