using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("HavenbagFurnitures", true)]
  public class HavenbagFurniture : IDataObject
  {
    public const string MODULE = "HavenbagFurnitures";
    public int TypeId;
    public int ThemeId;
    public int ElementId;
    public int Color;
    public int SkillId;
    public int LayerId;
    public bool BlocksMovement;
    public bool IsStackable;
    public uint CellsWidth;
    public uint CellsHeight;
    public uint Order;
  }
}
