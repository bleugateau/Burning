using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightMutantInformations : GameFightFighterNamedInformations
  {
    public new const uint Id = 50;
    public uint powerLevel;

    public override uint TypeId
    {
      get
      {
        return 50;
      }
    }

    public GameFightMutantInformations()
    {
    }

    public GameFightMutantInformations(
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
      uint powerLevel)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions, name, status, leagueId, ladderPosition, hiddenInPrefight)
    {
      this.powerLevel = powerLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.powerLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.powerLevel + ") on element powerLevel.");
      writer.WriteByte((byte) this.powerLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.powerLevel = (uint) reader.ReadByte();
      if (this.powerLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.powerLevel + ") on element of GameFightMutantInformations.powerLevel.");
    }
  }
}
