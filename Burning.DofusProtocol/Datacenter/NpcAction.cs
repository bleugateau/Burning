using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("NpcActions", true)]
  public class NpcAction : IDataObject
  {
    public const string MODULE = "NpcActions";
    public int Id;
    public int RealId;
    public uint NameId;
  }
}
