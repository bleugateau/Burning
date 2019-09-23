using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("IncarnationLevels", true)]
  public class IncarnationLevel : IDataObject
  {
    public const string MODULE = "IncarnationLevels";
    public int Id;
    public int IncarnationId;
    public int Level;
    public uint RequiredXp;
  }
}
