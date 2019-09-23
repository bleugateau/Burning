using System.Collections.Generic;

namespace Burning.DofusProtocol.Data.D2o.other
{
    [D2oClass("AnimFunNpcData", true)]
    public class AnimFunNpcData : AnimFunData
    {
        public List<AnimFunNpcData> SubAnimFunData;
    }
}
