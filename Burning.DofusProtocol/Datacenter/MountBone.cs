using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MountBones", true)]
  public class MountBone : IDataObject
  {
    private string MODULE = "MountBones";
    public uint Id;
  }
}
