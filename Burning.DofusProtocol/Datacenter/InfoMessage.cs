using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("InfoMessages", true)]
  public class InfoMessage : IDataObject
  {
    public const string MODULE = "InfoMessages";
    public uint TypeId;
    public uint MessageId;
    public uint TextId;
  }
}
