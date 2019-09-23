using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentBalance", true)]
  public class AlignmentBalance : IDataObject
  {
    public const string MODULE = "AlignmentBalance";
    public int Id;
    public int StartValue;
    public int EndValue;
    public uint NameId;
    public uint DescriptionId;
  }
}
