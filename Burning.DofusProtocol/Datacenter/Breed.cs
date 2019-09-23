using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Breeds", true)]
  public class Breed : IDataObject
  {
    public const string MODULE = "Breeds";
    public int Id;
    public uint ShortNameId;
    public uint LongNameId;
    public uint DescriptionId;
    public uint GameplayDescriptionId;
    public string MaleLook;
    public string FemaleLook;
    public uint CreatureBonesId;
    public int MaleArtwork;
    public int FemaleArtwork;
    public List<List<uint>> StatsPointsForStrength;
    public List<List<uint>> StatsPointsForIntelligence;
    public List<List<uint>> StatsPointsForChance;
    public List<List<uint>> StatsPointsForAgility;
    public List<List<uint>> StatsPointsForVitality;
    public List<List<uint>> StatsPointsForWisdom;
    public List<uint> BreedSpellsId;
    public List<BreedRoleByBreed> BreedRoles;
    public List<uint> MaleColors;
    public List<uint> FemaleColors;
    public uint SpawnMap;
    public uint Complexity;
    public uint SortIndex;
    public uint GameplayClassDescriptionId;
  }
}
