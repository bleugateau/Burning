using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterInformations : GameContextActorInformations
  {
    public List<uint> previousPositions = new List<uint>();
    public new const uint Id = 143;
    public GameContextBasicSpawnInformation spawnInfo;
    public uint wave;
    public GameFightMinimalStats stats;

    public override uint TypeId
    {
      get
      {
        return 143;
      }
    }

    public GameFightFighterInformations()
    {
    }

    public GameFightFighterInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions)
      : base(contextualId, disposition, look)
    {
      this.spawnInfo = spawnInfo;
      this.wave = wave;
      this.stats = stats;
      this.previousPositions = previousPositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.spawnInfo.Serialize(writer);
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element wave.");
      writer.WriteByte((byte) this.wave);
      writer.WriteShort((short) this.stats.TypeId);
      this.stats.Serialize(writer);
      writer.WriteShort((short) this.previousPositions.Count);
      for (int index = 0; index < this.previousPositions.Count; ++index)
      {
        if (this.previousPositions[index] < 0U || this.previousPositions[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.previousPositions[index] + ") on element 4 (starting at 1) of previousPositions.");
        writer.WriteVarShort((short) this.previousPositions[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.spawnInfo = new GameContextBasicSpawnInformation();
      this.spawnInfo.Deserialize(reader);
      this.wave = (uint) reader.ReadByte();
      if (this.wave < 0U)
        throw new Exception("Forbidden value (" + (object) this.wave + ") on element of GameFightFighterInformations.wave.");
      this.stats = ProtocolTypeManager.GetInstance<GameFightMinimalStats>((uint) reader.ReadUShort());
      this.stats.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of previousPositions.");
        this.previousPositions.Add(num2);
      }
    }
  }
}
