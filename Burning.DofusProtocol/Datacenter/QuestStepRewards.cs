using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestStepRewards", true)]
  public class QuestStepRewards : IDataObject
  {
    public const string MODULE = "QuestStepRewards";
    public uint Id;
    public uint StepId;
    public int LevelMin;
    public int LevelMax;
    public double KamasRatio;
    public double ExperienceRatio;
    public bool KamasScaleWithPlayerLevel;
    public List<List<uint>> ItemsReward;
    public List<uint> EmotesReward;
    public List<uint> JobsReward;
    public List<uint> SpellsReward;
    public List<uint> TitlesReward;
  }
}
