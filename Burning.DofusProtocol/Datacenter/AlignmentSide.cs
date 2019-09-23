using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentSides", true)]
  public class AlignmentSide : IDataObject
  {
    public const string MODULE = "AlignmentSides";
    public int Id;
    public uint NameId;
    public bool CanConquest;
  }
}
