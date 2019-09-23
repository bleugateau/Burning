using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("NpcMessages", true)]
  public class NpcMessage : IDataObject
  {
    public const string MODULE = "NpcMessages";
    public int Id;
    public uint MessageId;
    public List<string> MessageParams;
  }
}
