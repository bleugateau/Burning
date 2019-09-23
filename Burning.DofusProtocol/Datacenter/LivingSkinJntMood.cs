using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("LivingSkinJntMood", true)]
  public class LivingSkinJntMood : IDataObject
  {
    public const string MODULE = "LivingSkinJntMood";
    public int SkinId;
    public List<List<int>> Moods;
  }
}
