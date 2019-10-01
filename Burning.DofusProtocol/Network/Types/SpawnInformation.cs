using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.DofusProtocol.Network.Types
{
    public class SpawnInformation
    {
        public const uint Id = 575;

        public virtual uint TypeId
        {
            get
            {
                return 575;
            }
        }

        public SpawnInformation()
        {
        }

        public virtual void Serialize(IDataWriter writer)
        {
           
        }

        public virtual void Deserialize(IDataReader reader)
        {
           
        }
    }
}