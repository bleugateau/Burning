using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MonsterRaces", true)]
  public class MonsterRace : IDataObject
  {
    public const string MODULE = "MonsterRaces";
    public int Id;
    public int SuperRaceId;
    public uint NameId;
    public List<uint> Monsters;
    public int AggressiveZoneSize;
    public int AggressiveLevelDiff;
    public string AggressiveImmunityCriterion;
    public int AggressiveAttackDelay;
  }
}
