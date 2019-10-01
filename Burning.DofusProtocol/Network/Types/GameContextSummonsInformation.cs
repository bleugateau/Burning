using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
    public class GameContextSummonsInformation
    {
        public List<GameContextBasicSpawnInformation> summons = new List<GameContextBasicSpawnInformation>();
        public const uint Id = 567;
        public SpawnInformation spawnInformation;
        public uint wave;
        public EntityLook look;
        public GameFightMinimalStats stats;

        public virtual uint TypeId
        {
            get
            {
                return 567;
            }
        }

        public GameContextSummonsInformation()
        {
        }

        public GameContextSummonsInformation(
          SpawnInformation spawnInformation,
          uint wave,
          EntityLook look,
          GameFightMinimalStats stats,
          List<GameContextBasicSpawnInformation> summons)
        {
            this.spawnInformation = spawnInformation;
            this.wave = wave;
            this.look = look;
            this.stats = stats;
            this.summons = summons;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)this.spawnInformation.TypeId);
            this.spawnInformation.Serialize(writer);

            if (this.wave < 0U)
                throw new Exception("Forbidden value (" + (object)this.wave + ") on element wave.");
            writer.WriteByte((byte)this.wave);
            this.look.Serialize(writer);
            writer.WriteShort((short)this.stats.TypeId);
            this.stats.Serialize(writer);
            writer.WriteShort((short)this.summons.Count);
            for (int index = 0; index < this.summons.Count; ++index)
            {
                writer.WriteShort((short)this.summons[index].TypeId);
                this.summons[index].Serialize(writer);
            }
        }

        public virtual void Deserialize(IDataReader reader)
        {
            //this.spawnInformation = ProtocolTypeManager.getInstance(SpawnInformation, _id1);
            this.spawnInformation = ProtocolTypeManager.GetInstance<SpawnInformation>((uint)reader.ReadUShort());
            this.spawnInformation.Deserialize(reader);
            this.wave = (uint)reader.ReadByte();
            if (this.wave < 0U)
                throw new Exception("Forbidden value (" + (object)this.wave + ") on element of GameContextSummonsInformation.wave.");
            this.look = new EntityLook();
            this.look.Deserialize(reader);
            this.stats = ProtocolTypeManager.GetInstance<GameFightMinimalStats>((uint)reader.ReadUShort());
            this.stats.Deserialize(reader);
            uint num = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num; ++index)
            {
                GameContextBasicSpawnInformation instance = ProtocolTypeManager.GetInstance<GameContextBasicSpawnInformation>((uint)reader.ReadUShort());
                instance.Deserialize(reader);
                this.summons.Add(instance);
            }
        }
    }
}
