using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("TaxCollectorNames", true)]
  public class TaxCollectorName : IDataObject
  {
    public const string MODULE = "TaxCollectorNames";
    public int Id;
    public uint NameId;
  }
}
