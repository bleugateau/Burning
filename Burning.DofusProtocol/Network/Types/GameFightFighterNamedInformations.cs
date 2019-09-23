using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameFightFighterNamedInformations : GameFightFighterInformations
  {
    public new const uint Id = 158;
    public string name;
    public PlayerStatus status;
    public int leagueId;
    public int ladderPosition;
    public bool hiddenInPrefight;

    public override uint TypeId
    {
      get
      {
        return 158;
      }
    }

    public GameFightFighterNamedInformations()
    {
    }

    public GameFightFighterNamedInformations(
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
      bool hiddenInPrefight)
      : base(contextualId, disposition, look, spawnInfo, wave, stats, previousPositions)
    {
      this.name = name;
      this.status = status;
      this.leagueId = leagueId;
      this.ladderPosition = ladderPosition;
      this.hiddenInPrefight = hiddenInPrefight;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
      this.status.Serialize(writer);
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteInt(this.ladderPosition);
      writer.WriteBoolean(this.hiddenInPrefight);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
      this.status = new PlayerStatus();
      this.status.Deserialize(reader);
      this.leagueId = (int) reader.ReadVarShort();
      this.ladderPosition = reader.ReadInt();
      this.hiddenInPrefight = reader.ReadBoolean();
    }
  }
}
