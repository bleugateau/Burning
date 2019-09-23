using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Ornaments", true)]
  public class Ornament : IDataObject
  {
    public const string MODULE = "Ornaments";
    public int Id;
    public uint NameId;
    public bool Visible;
    public int AssetId;
    public int IconId;
    public int Rarity;
    public int Order;
  }
}
