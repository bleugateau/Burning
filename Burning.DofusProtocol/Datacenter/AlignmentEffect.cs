using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentEffect", true)]
  public class AlignmentEffect : IDataObject
  {
    public const string MODULE = "AlignmentEffect";
    public int Id;
    public uint CharacteristicId;
    public uint DescriptionId;
  }
}
