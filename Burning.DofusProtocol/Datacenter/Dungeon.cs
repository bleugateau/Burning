using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Dungeons", true)]
  public class Dungeon : IDataObject
  {
    public const string MODULE = "Dungeons";
    public int Id;
    public uint NameId;
    public int OptimalPlayerLevel;
    public List<double> MapIds;
    public double EntranceMapId;
    public double ExitMapId;
  }
}
