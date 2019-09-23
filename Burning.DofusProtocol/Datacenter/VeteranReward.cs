using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("VeteranRewards", true)]
  public class VeteranReward : IDataObject
  {
    public const string MODULE = "VeteranRewards";
    public int Id;
    public uint RequiredSubDays;
    public uint ItemGID;
    public uint ItemQuantity;
  }
}
