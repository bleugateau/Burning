using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("BreedRoles", true)]
  public class BreedRole : IDataObject
  {
    public const string MODULE = "BreedRoles";
    public int Id;
    public uint NameId;
    public uint DescriptionId;
    public int AssetId;
    public int Color;
  }
}
