using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("SpeakingItemsTriggers", true)]
  public class SpeakingItemsTrigger : IDataObject
  {
    public const string MODULE = "SpeakingItemsTriggers";
    public int TriggersId;
    public List<int> TextIds;
    public List<int> States;
  }
}
