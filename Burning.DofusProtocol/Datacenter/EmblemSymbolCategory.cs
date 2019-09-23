using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EmblemSymbolCategories", true)]
  public class EmblemSymbolCategory : IDataObject
  {
    public const string MODULE = "EmblemSymbolCategories";
    public int Id;
    public uint NameId;
  }
}
