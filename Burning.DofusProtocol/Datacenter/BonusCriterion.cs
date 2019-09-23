using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("BonusesCriterions", true)]
  public class BonusCriterion : IDataObject
  {
    public const string MODULE = "BonusesCriterions";
    public int Id;
    public uint Type;
    public int Value;
  }
}
