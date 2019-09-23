using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("LegendaryPowersCategories", true)]
  public class LegendaryPowerCategory : IDataObject
  {
    public const string MODULE = "LegendaryPowersCategories";
    public int Id;
    public string CategoryName;
    public bool CategoryOverridable;
    public List<int> CategorySpells;
  }
}
