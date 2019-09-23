using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MapPositions", true)]
  public class MapPosition : IDataObject
  {
    public const string MODULE = "MapPositions";
    public double Id;
    public int PosX;
    public int PosY;
    public bool Outdoor;
    public int Capabilities;
    public int NameId;
    public bool ShowNameOnFingerpost;
    public List<AmbientSound> Sounds;
    public List<List<int>> Playlists;
    public int SubAreaId;
    public int WorldMap;
    public bool HasPriorityOnWorldmap;
    public bool IsUnderWater;
    public bool IsTransition;
    public int TacticalModeTemplateId;
    public bool AllowPrism;
  }
}
