using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("ServerPopulations", true)]
  public class ServerPopulation : IDataObject
  {
    public const string MODULE = "ServerPopulations";
    public int Id;
    public uint NameId;
    public int Weight;
  }
}
