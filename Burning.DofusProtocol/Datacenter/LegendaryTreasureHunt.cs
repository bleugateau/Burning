using Burning.DofusProtocol.Data.D2o;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("LegendaryTreasureHunts", true)]
  public class LegendaryTreasureHunt : IDataObject
  {
    public const string MODULE = "LegendaryTreasureHunts";
    public uint Id;
    public uint NameId;
    public uint Level;
    public uint ChestId;
    public uint MonsterId;
    public uint MapItemId;
    public double XpRatio;
  }
}
