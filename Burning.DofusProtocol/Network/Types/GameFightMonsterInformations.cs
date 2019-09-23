using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightMonsterInformations : GameFightAIInformations
  {
    public new const uint Id = 29;
    public uint creatureGenericId;
    public uint creatureGrade;
    public uint creatureLevel;

    public override uint TypeId
    {
      get
      {
        return 29;
      }
    }

    public GameFightMonsterInformations()
    {
    }

    public GameFightMonsterInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions,
      uint creatureGenericId,
      uint creatureGrade,
      uint creatureLevel)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
    {
      this.creatureGenericId = creatureGenericId;
      this.creatureGrade = creatureGrade;
      this.creatureLevel = creatureLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element creatureGenericId.");
      writer.WriteVarShort((short) this.creatureGenericId);
      if (this.creatureGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGrade + ") on element creatureGrade.");
      writer.WriteByte((byte) this.creatureGrade);
      if (this.creatureLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureLevel + ") on element creatureLevel.");
      writer.WriteShort((short) this.creatureLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.creatureGenericId = (uint) reader.ReadVarUhShort();
      if (this.creatureGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGenericId + ") on element of GameFightMonsterInformations.creatureGenericId.");
      this.creatureGrade = (uint) reader.ReadByte();
      if (this.creatureGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureGrade + ") on element of GameFightMonsterInformations.creatureGrade.");
      this.creatureLevel = (uint) reader.ReadShort();
      if (this.creatureLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.creatureLevel + ") on element of GameFightMonsterInformations.creatureLevel.");
    }
  }
}
