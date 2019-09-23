using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("StealthBones", true)]
  public class StealthBones : IDataObject
  {
    public const string MODULE = "StealthBones";
    public uint Id;
  }
}
