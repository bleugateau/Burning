using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
  [D2oClass("AnimFunNpcData", true)]
  public class AnimFunNpcData
  {
    public List<AnimFunNpcData> SubAnimFunData;
  }
}
