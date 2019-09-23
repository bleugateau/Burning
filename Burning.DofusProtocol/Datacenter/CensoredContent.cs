using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("CensoredContents", true)]
  public class CensoredContent : IDataObject
  {
    public const string MODULE = "CensoredContents";
    public int Type;
    public int OldValue;
    public int NewValue;
    public string Lang;
  }
}
