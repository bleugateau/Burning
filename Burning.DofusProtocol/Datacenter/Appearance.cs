using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Appearances", true)]
  public class Appearance : IDataObject
  {
    public const string MODULE = "Appearances";
    public uint Id;
    public uint Type;
    public string Data;
  }
}
