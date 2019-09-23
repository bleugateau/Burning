using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentOrder", true)]
  public class AlignmentOrder : IDataObject
  {
    public const string MODULE = "AlignmentOrder";
    public int Id;
    public uint NameId;
    public uint SideId;
  }
}
