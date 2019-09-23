using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightCharacterInformations : GameFightFighterNamedInformations
  {
    public new const uint Id = 46;
    public uint level;
    public ActorAlignmentInformations alignmentInfos;
    public int breed;
    public bool sex;

    public override uint TypeId
    {
      get
      {
        return 46;
      }
    }

    public GameFightCharacterInformations()
    {
    }

    public GameFightCharacterInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GameContextBasicSpawnInformation spawnInfo,
      uint wave,
      GameFightMinimalStats stats,
      List<uint> previousPositions,
      string name,
      PlayerStatus status,
      int leagueId,
      int ladderPosition,
      bool hiddenInPrefight,
      uint level,
      ActorAlignmentInformations alignmentInfos,
      int breed,
      bool sex)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, name, status, leagueId, ladderPosition, hiddenInPrefight)
    {
      this.level = level;
      this.alignmentInfos = alignmentInfos;
      this.breed = breed;
      this.sex = sex;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      this.alignmentInfos.Serialize(writer);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of GameFightCharacterInformations.level.");
      this.alignmentInfos = new ActorAlignmentInformations();
      this.alignmentInfos.Deserialize(reader);
      this.breed = (int) reader.ReadByte();
      this.sex = reader.ReadBoolean();
    }
  }
}
