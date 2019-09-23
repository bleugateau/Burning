using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SmileyCategories", true)]
  public class SmileyCategory : IDataObject
  {
    public const string MODULE = "SmileyCategories";
    public int Id;
    public uint Order;
    public string GfxId;
    public bool IsFake;
  }
}
