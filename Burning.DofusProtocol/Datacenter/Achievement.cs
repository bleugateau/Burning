using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("Achievements", true)]
  public class Achievement : IDataObject
  {
    public const string MODULE = "Achievements";
    public uint Id;
    public uint NameId;
    public uint CategoryId;
    public uint DescriptionId;
    public int IconId;
    public uint Points;
    public uint Level;
    public uint Order;
    public bool AccountLinked;
    public List<int> ObjectiveIds;
    public List<int> RewardIds;
  }
}
