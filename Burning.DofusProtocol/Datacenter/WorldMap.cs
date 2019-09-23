using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("WorldMaps", true)]
  public class WorldMap : IDataObject
  {
    public const string MODULE = "WorldMaps";
    public int Id;
    public uint NameId;
    public int OrigineX;
    public int OrigineY;
    public double MapWidth;
    public double MapHeight;
    public uint HorizontalChunck;
    public uint VerticalChunck;
    public bool ViewableEverywhere;
    public double MinScale;
    public double MaxScale;
    public double StartScale;
    public int CenterX;
    public int CenterY;
    public int TotalWidth;
    public int TotalHeight;
    public List<string> Zoom;
  }
}
