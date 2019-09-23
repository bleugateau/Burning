using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MountFamily", true)]
  public class MountFamily : IDataObject
  {
    private string MODULE = nameof (MountFamily);
    public uint Id;
    public uint NameId;
    public string HeadUri;
  }
}
