using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ServerLangs", true)]
  public class ServerLang : IDataObject
  {
    public const string MODULE = "ServerLangs";
    public int Id;
    public uint NameId;
    public string LangCode;
  }
}
