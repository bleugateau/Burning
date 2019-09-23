using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightTaxCollectorInformations : GameFightAIInformations
  {
    public new const uint Id = 48;
    public uint firstNameId;
    public uint lastNameId;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 48;
      }
    }

    public GameFightTaxCollectorInformations()
    {
    }

    public GameFightTaxCollectorInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions,
      uint firstNameId,
      uint lastNameId,
      uint level)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
    {
      this.firstNameId = firstNameId;
      this.lastNameId = lastNameId;
      this.level = level;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element firstNameId.");
      writer.WriteVarShort((short) this.firstNameId);
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element lastNameId.");
      writer.WriteVarShort((short) this.lastNameId);
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.firstNameId = (uint) reader.ReadVarUhShort();
      if (this.firstNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.firstNameId + ") on element of GameFightTaxCollectorInformations.firstNameId.");
      this.lastNameId = (uint) reader.ReadVarUhShort();
      if (this.lastNameId < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNameId + ") on element of GameFightTaxCollectorInformations.lastNameId.");
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of GameFightTaxCollectorInformations.level.");
    }
  }
}
