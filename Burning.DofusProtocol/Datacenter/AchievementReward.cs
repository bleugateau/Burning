using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AchievementRewards", true)]
  public class AchievementReward : IDataObject
  {
    public const string MODULE = "AchievementRewards";
    public uint Id;
    public uint AchievementId;
    public string Criteria;
    public double KamasRatio;
    public double ExperienceRatio;
    public bool KamasScaleWithPlayerLevel;
    public List<uint> ItemsReward;
    public List<uint> ItemsQuantityReward;
    public List<uint> EmotesReward;
    public List<uint> SpellsReward;
    public List<uint> TitlesReward;
    public List<uint> OrnamentsReward;
  }
}
