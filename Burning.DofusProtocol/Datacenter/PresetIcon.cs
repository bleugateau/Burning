using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("PresetIcons", true)]
  public class PresetIcon : IDataObject
  {
    public const string MODULE = "PresetIcons";
    public int Id;
    public int Order;
  }
}
