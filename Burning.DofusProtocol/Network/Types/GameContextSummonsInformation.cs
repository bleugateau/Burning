using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameContextSummonsInformation
  {
    public List<GameContextBasicSpawnInformation> summons = new List<GameContextBasicSpawnInformation>();
    public const uint Id = 567;
    public uint creatureGenericId;
    public uint creatureGrade;
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
      uint creatureGenericId,
      uint creatureGrade,
      uint wave,
      EntityLook look,
      GameFightMinimalStats stats,
      List<GameContextBasicSpawnInformation> summons)
    {
      this.creatureGenericId = creatureGenericId;
      this.creatureGrade = creatureGrade;
      this.wave = wave;
      this.look = look;
      this.stats = stats;
      this.summons = summons;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element creatureGenericId.");
      writer.WriteVarShort((short) this.creatureGenericId);
      if (this.creatureGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGrade + ") on element creatureGrade.");
      writer.WriteByte((byte) this.creatureGrade);
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element wave.");
      writer.WriteByte((byte) this.wave);
      this.look.Serialize(writer);
      writer.WriteShort((short) this.stats.TypeId);
      this.stats.Serialize(writer);
      writer.WriteShort((short) this.summons.Count);
      for (int index = 0; index < this.summons.Count; ++index)
      {
        writer.WriteShort((short) this.summons[index].TypeId);
        this.summons[index].Serialize(writer);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.creatureGenericId = (uint) reader.ReadVarUhShort();
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element of GameContextSummonsInformation.creatureGenericId.");
      this.creatureGrade = (uint) reader.ReadByte();
      if (this.creatureGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGrade + ") on element of GameContextSummonsInformation.creatureGrade.");
      this.wave = (uint) reader.ReadByte();
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element of GameContextSummonsInformation.wave.");
      this.look = new EntityLook();
      this.look.Deserialize(reader);
      this.stats = ProtocolTypeManager.GetInstance<GameFightMinimalStats>((uint) reader.ReadUShort());
      this.stats.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameContextBasicSpawnInformation instance = ProtocolTypeManager.GetInstance<GameContextBasicSpawnInformation>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.summons.Add(instance);
      }
    }
  }
}
