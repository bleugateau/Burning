using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("IdolsPresetIcons", true)]
  public class IdolsPresetIcon : IDataObject
  {
    public const string MODULE = "IdolsPresetIcons";
    public int Id;
    public int Order;
  }
}
