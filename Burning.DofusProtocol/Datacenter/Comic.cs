using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Comics", true)]
  public class Comic : IDataObject
  {
    private const string MODULE = "Comics";
    public int Id;
    public string RemoteId;
  }
}
