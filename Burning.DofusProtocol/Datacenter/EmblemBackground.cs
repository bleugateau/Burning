using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("EmblemBackgrounds", true)]
  public class EmblemBackground : IDataObject
  {
    public const string MODULE = "EmblemBackgrounds";
    public int Id;
    public int Order;
  }
}
