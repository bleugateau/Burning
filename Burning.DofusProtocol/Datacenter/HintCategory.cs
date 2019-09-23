using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("HintCategory", true)]
  public class HintCategory : IDataObject
  {
    public const string MODULE = "HintCategory";
    public int Id;
    public uint NameId;
  }
}
