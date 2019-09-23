using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AchievementCategories", true)]
  public class AchievementCategory : IDataObject
  {
    public const string MODULE = "AchievementCategories";
    public uint Id;
    public uint NameId;
    public uint ParentId;
    public string Icon;
    public uint Order;
    public string Color;
    public List<uint> AchievementIds;
    public string VisibilityCriterion;
  }
}
