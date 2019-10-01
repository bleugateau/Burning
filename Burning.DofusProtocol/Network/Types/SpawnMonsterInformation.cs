using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.DofusProtocol.Network.Types
{
    public class SpawnMonsterInformation : SpawnInformation
    {
        public const uint Id = 572;

        public virtual uint TypeId
        {
            get
            {
                return 572;
            }
        }

        public uint creatureGenericId;

        public uint creatureGrade;

        public SpawnMonsterInformation() { }

        public SpawnMonsterInformation(uint creatureGenericId, uint creatureGrade)
        {
            this.creatureGenericId = creatureGenericId;
            this.creatureGrade = creatureGrade;
        }

        public override void Serialize(IDataWriter writer)
        {
            if (this.creatureGenericId < 0)
            {
                throw new Exception("Forbidden value (" + this.creatureGenericId + ") on element creatureGenericId.");
            }
            writer.WriteVarShort((short)this.creatureGenericId);
            if (this.creatureGrade < 0)
            {
                throw new Exception("Forbidden value (" + this.creatureGrade + ") on element creatureGrade.");
            }
            writer.WriteByte((byte)this.creatureGrade);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.creatureGenericId = reader.ReadVarUhShort();
            if (this.creatureGenericId < 0)
            {
                throw new Exception("Forbidden value (" + this.creatureGenericId + ") on element of SpawnMonsterInformation.creatureGenericId.");
            }
            this.creatureGrade = reader.ReadByte();
            if (this.creatureGrade < 0)
            {
                throw new Exception("Forbidden value (" + this.creatureGrade + ") on element of SpawnMonsterInformation.creatureGrade.");
            }
        }
    }
}
