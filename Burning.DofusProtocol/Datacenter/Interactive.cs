using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Interactives", true)]
  public class Interactive : IDataObject
  {
    public const string MODULE = "Interactives";
    public int Id;
    public uint NameId;
    public int ActionId;
    public bool DisplayTooltip;
  }
}
