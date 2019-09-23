using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Jobs", true)]
  public class Job : IDataObject
  {
    public const string MODULE = "Jobs";
    public int Id;
    public uint NameId;
    public int IconId;
  }
}
