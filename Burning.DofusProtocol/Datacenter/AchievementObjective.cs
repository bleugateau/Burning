using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AchievementObjectives", true)]
  public class AchievementObjective : IDataObject
  {
    public const string MODULE = "AchievementObjectives";
    public uint Id;
    public uint AchievementId;
    public uint Order;
    public uint NameId;
    public string Criterion;
  }
}
