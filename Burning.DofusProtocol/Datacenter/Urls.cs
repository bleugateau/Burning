using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Url", true)]
  public class Urls : IDataObject
  {
    public const string MODULE = "Url";
    public int Id;
    public int BrowserId;
    public string Url;
    public string Param;
    public string Method;
  }
}
