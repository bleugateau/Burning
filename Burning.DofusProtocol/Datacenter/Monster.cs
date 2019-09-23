using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Monsters", true)]
  public class Monster : IDataObject
  {
    public const string MODULE = "Monsters";
    public int Id;
    public uint NameId;
    public uint GfxId;
    public int Race;
    public List<MonsterGrade> Grades;
    public string Look;
    public bool UseSummonSlot;
    public bool UseBombSlot;
    public bool CanPlay;
    public bool CanTackle;
    public List<AnimFunMonsterData> AnimFunList;
    public bool IsBoss;
    public List<MonsterDrop> Drops;
    public List<uint> Subareas;
    public List<uint> Spells;
    public int FavoriteSubareaId;
    public bool IsMiniBoss;
    public bool IsQuestMonster;
    public uint CorrespondingMiniBossId;
    public double SpeedAdjust;
    public int CreatureBoneId;
    public bool CanBePushed;
    public bool CanBeCarried;
    public bool CanUsePortal;
    public bool CanSwitchPos;
    public bool FastAnimsFun;
    public List<uint> IncompatibleIdols;
    public bool AllIdolsDisabled;
    public bool DareAvailable;
    public List<uint> IncompatibleChallenges;
    public bool UseRaceValues;
    public int AggressiveZoneSize;
    public int AggressiveLevelDiff;
    public string AggressiveImmunityCriterion;
    public int AggressiveAttackDelay;
    public List<MonsterDrop> TemporisDrops;
  }
}
