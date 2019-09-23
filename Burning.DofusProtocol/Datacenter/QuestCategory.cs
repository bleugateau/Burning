using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("QuestCategory", true)]
  public class QuestCategory : IDataObject
  {
    public const string MODULE = "QuestCategory";
    public uint Id;
    public uint NameId;
    public uint Order;
    public List<uint> QuestIds;
  }
}
