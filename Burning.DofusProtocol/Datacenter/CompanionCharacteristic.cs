using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CompanionCharacteristics", true)]
  public class CompanionCharacteristic : IDataObject
  {
    public const string MODULE = "CompanionCharacteristics";
    public int Id;
    public int CaracId;
    public int CompanionId;
    public int Order;
    public List<List<double>> StatPerLevelRange;
  }
}
