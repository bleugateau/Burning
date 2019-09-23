using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Bonuses", true)]
  public class Bonus : IDataObject
  {
    public const string MODULE = "Bonuses";
    public int Id;
    public uint Type;
    public int Amount;
    public List<int> CriterionsIds;
  }
}
