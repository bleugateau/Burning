using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.DofusProtocol.Network.Types
{
    public class SpawnCharacterInformation : SpawnInformation
    {
        public const uint Id = 574;
        public double id;

        public virtual uint TypeId
        {
            get
            {
                return 574;
            }
        }

        public string name;

        public uint level;

        public SpawnCharacterInformation () { }

        public SpawnCharacterInformation(string name, uint level)
        {
            this.name = name;
            this.level = level;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(this.name);
            if (this.level < 1 || this.level > 200)
            {
                throw new Exception("Forbidden value (" + this.level + ") on element level.");
            }
            writer.WriteVarShort((short)this.level);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.name = reader.ReadUTF();
            this.level = reader.ReadVarUhShort();
            if (this.level < 1 || this.level > 200)
            {
                throw new Exception("Forbidden value (" + this.level + ") on element of SpawnCharacterInformation.level.");
            }
        }
    }
}
