using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("BreachBosses", true)]
  public class BreachBoss : IDataObject
  {
    public const string MODULE = "BreachBosses";
    public int Id;
    public int MonsterId;
    public int Category;
    public string ApparitionCriterion;
    public string AccessCriterion;
    public int MaxRewardQuantity;
    public List<int> IncompatibleBosses;
    public uint RewardId;
  }
}
