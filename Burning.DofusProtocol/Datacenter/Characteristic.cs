using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Characteristics", true)]
  public class Characteristic : IDataObject
  {
    public const string MODULE = "Characteristics";
    public int Id;
    public string Keyword;
    public uint NameId;
    public string Asset;
    public int CategoryId;
    public bool Visible;
    public int Order;
    public bool Upgradable;
  }
}
