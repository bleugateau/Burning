using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Months", true)]
  public class Month : IDataObject
  {
    public const string MODULE = "Months";
    public int Id;
    public uint NameId;
  }
}
