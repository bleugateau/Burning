using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Documents", true)]
  public class Document : IDataObject
  {
    private const string MODULE = "Documents";
    public int Id;
    public uint TypeId;
    public bool ShowTitle;
    public bool ShowBackgroundImage;
    public uint TitleId;
    public uint AuthorId;
    public uint SubTitleId;
    public uint ContentId;
    public string ContentCSS;
    public string ClientProperties;
  }
}
