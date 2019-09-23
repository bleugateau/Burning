using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("DareCriterias", true)]
  public class DareCriteria : IDataObject
  {
    public const string MODULE = "DareCriterias";
    public uint Id;
    public uint NameId;
    public uint MaxOccurence;
    public uint MaxParameters;
    public int MinParameterBound;
    public int MaxParameterBound;
  }
}
