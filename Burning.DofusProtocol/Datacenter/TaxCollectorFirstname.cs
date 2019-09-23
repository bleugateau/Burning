using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("TaxCollectorFirstnames", true)]
  public class TaxCollectorFirstname : IDataObject
  {
    public const string MODULE = "TaxCollectorFirstnames";
    public int Id;
    public uint FirstnameId;
  }
}
