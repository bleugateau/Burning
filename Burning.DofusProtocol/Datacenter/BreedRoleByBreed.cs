using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("BreedRoleByBreeds", true)]
  public class BreedRoleByBreed : IDataObject
  {
    public const string MODULE = "BreedRoleByBreeds";
    public int BreedId;
    public int RoleId;
    public uint DescriptionId;
    public int Value;
    public int Order;
  }
}
