using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Hints", true)]
  public class Hint : IDataObject
  {
    public const string MODULE = "Hints";
    public int Id;
    public uint Gfx;
    public uint NameId;
    public double MapId;
    public double RealMapId;
    public int X;
    public int Y;
    public bool Outdoor;
    public int SubareaId;
    public int WorldMapId;
    public uint Level;
    public int CategoryId;
  }
}
