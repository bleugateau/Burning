using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("RideFood", true)]
  public class RideFood : IDataObject
  {
    public string MODULE = nameof (RideFood);
    public uint Gid;
    public uint TypeId;
    public int FamilyId;
  }
}
