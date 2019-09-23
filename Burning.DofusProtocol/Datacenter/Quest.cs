using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Quests", true)]
  public class Quest : IDataObject
  {
    public const string MODULE = "Quests";
    public uint Id;
    public uint NameId;
    public List<uint> StepIds;
    public uint CategoryId;
    public uint RepeatType;
    public uint RepeatLimit;
    public bool IsDungeonQuest;
    public uint LevelMin;
    public uint LevelMax;
    public bool IsPartyQuest;
    public string StartCriterion;
    public bool Followable;
  }
}
