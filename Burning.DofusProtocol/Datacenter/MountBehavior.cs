using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("MountBehaviors", true)]
  public class MountBehavior : IDataObject
  {
    public const string MODULE = "MountBehaviors";
    public uint Id;
    public uint NameId;
    public uint DescriptionId;
  }
}
