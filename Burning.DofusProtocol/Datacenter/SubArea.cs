using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Data.D2o.other;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SubAreas", true)]
  public class SubArea : IDataObject
  {
    public const string MODULE = "SubAreas";
    public int Id;
    public uint NameId;
    public int AreaId;
    public List<AmbientSound> AmbientSounds;
    public List<List<int>> Playlists;
    public List<double> MapIds;
    public Rectangle Bounds;
    public List<int> Shape;
    public List<uint> CustomWorldMap;
    public int PackId;
    public uint Level;
    public bool IsConquestVillage;
    public bool BasicAccountAllowed;
    public bool DisplayOnWorldMap;
    public bool MountAutoTripAllowed;
    public List<uint> Monsters;
    public List<double> EntranceMapIds;
    public List<double> ExitMapIds;
    public bool Capturable;
    public List<uint> Achievements;
    public List<List<double>> Quests;
    public List<List<double>> Npcs;
    public int ExploreAchievementId;
    public bool IsDiscovered;
    public List<int> Harvestables;
    public int AssociatedZaapMapId;
  }
}
