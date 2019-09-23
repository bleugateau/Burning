using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EmblemSymbols", true)]
  public class EmblemSymbol : IDataObject
  {
    public const string MODULE = "EmblemSymbols";
    public int Id;
    public int IconId;
    public int SkinId;
    public int Order;
    public int CategoryId;
    public bool Colorizable;
  }
}
