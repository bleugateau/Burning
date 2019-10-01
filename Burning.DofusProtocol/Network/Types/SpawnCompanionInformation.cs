using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burning.DofusProtocol.Network.Types
{
    public class SpawnCompanionInformation : SpawnInformation
    {
        public const uint Id = 573;

        public virtual uint TypeId
        {
            get
            {
                return 573;
            }
        }

        public uint modelId;

        public uint level;

        public double summonerId;

        public double ownerId;

        public SpawnCompanionInformation() { }

        public SpawnCompanionInformation(uint modelId, uint level, double summonerId, double ownerId)
        {
            this.modelId = modelId;
            this.level = level;
            this.summonerId = summonerId;
            this.ownerId = ownerId;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            if (this.modelId < 0)
            {
                throw new Exception("Forbidden value (" + this.modelId + ") on element modelId.");
            }
            writer.WriteByte((byte)this.modelId);
            if (this.level < 1 || this.level > 200)
            {
                throw new Exception("Forbidden value (" + this.level + ") on element level.");
            }
            writer.WriteVarShort((short)this.level);
            if (this.summonerId < -9007199254740990 || this.summonerId > 9007199254740990)
            {
                throw new Exception("Forbidden value (" + this.summonerId + ") on element summonerId.");
            }
            writer.WriteDouble(this.summonerId);
            if (this.ownerId < -9007199254740990 || this.ownerId > 9007199254740990)
            {
                throw new Exception("Forbidden value (" + this.ownerId + ") on element ownerId.");
            }
            writer.WriteDouble(this.ownerId);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            this.modelId = reader.ReadByte();
            if (this.modelId < 0)
            {
                throw new Exception("Forbidden value (" + this.modelId + ") on element of SpawnCompanionInformation.modelId.");
            }

            this.level = reader.ReadVarUhShort();
            if (this.level < 1 || this.level > 200)
            {
                throw new Exception("Forbidden value (" + this.level + ") on element of SpawnCompanionInformation.level.");
            }

            this.summonerId = reader.ReadDouble();
            if (this.summonerId < -9007199254740990 || this.summonerId > 9007199254740990)
            {
                throw new Exception("Forbidden value (" + this.summonerId + ") on element of SpawnCompanionInformation.summonerId.");
            }

            this.ownerId = reader.ReadDouble();
            if (this.ownerId < -9007199254740990 || this.ownerId > 9007199254740990)
            {
                throw new Exception("Forbidden value (" + this.ownerId + ") on element of SpawnCompanionInformation.ownerId.");
            }
        }
    }
}