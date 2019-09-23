using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Phoenixes", true)]
  public class Phoenix : IDataObject
  {
    public const string MODULE = "Phoenixes";
    public double MapId;
  }
}
