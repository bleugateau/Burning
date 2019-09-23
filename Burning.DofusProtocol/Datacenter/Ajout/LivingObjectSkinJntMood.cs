using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter.Ajout
{
  [D2oClass("LivingObjectSkinJntMood", true)]
  public class LivingObjectSkinJntMood : IDataObject
  {
    public const string MODULE = "LivingObjectSkinJntMood";
    public List<List<int>> Moods;
    public int SkinId;
  }
}
