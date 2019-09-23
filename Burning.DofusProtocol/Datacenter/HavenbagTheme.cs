using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("HavenbagThemes", true)]
  public class HavenbagTheme : IDataObject
  {
    public const string MODULE = "HavenbagThemes";
    public int Id;
    public int NameId;
    public double MapId;
  }
}
