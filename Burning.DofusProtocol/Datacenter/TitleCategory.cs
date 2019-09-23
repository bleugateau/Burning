using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("TitleCategories", true)]
  public class TitleCategory : IDataObject
  {
    public const string MODULE = "TitleCategories";
    public int Id;
    public uint NameId;
  }
}
