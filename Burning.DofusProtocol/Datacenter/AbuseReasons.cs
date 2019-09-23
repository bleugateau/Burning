using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AbuseReasons", true)]
  public class AbuseReasons : IDataObject
  {
    public const string MODULE = "AbuseReasons";
    public uint AbuseReasonId;
    public uint Mask;
    public int ReasonTextId;
  }
}
