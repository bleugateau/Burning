using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AlignmentRank", true)]
  public class AlignmentRank : IDataObject
  {
    public const string MODULE = "AlignmentRank";
    public int Id;
    public uint OrderId;
    public uint NameId;
    public uint DescriptionId;
    public int MinimumAlignment;
    public int ObjectsStolen;
    public List<int> Gifts;
  }
}
