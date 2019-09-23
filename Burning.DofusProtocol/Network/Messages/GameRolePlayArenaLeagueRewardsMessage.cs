using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaLeagueRewardsMessage : NetworkMessage
  {
    public const uint Id = 6785;
    public uint seasonId;
    public uint leagueId;
    public int ladderPosition;
    public bool endSeasonReward;

    public override uint MessageId
    {
      get
      {
        return 6785;
      }
    }

    public GameRolePlayArenaLeagueRewardsMessage()
    {
    }

    public GameRolePlayArenaLeagueRewardsMessage(
      uint seasonId,
      uint leagueId,
      int ladderPosition,
      bool endSeasonReward)
    {
      this.seasonId = seasonId;
      this.leagueId = leagueId;
      this.ladderPosition = ladderPosition;
      this.endSeasonReward = endSeasonReward;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.seasonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.seasonId + ") on element seasonId.");
      writer.WriteVarShort((short) this.seasonId);
      if (this.leagueId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leagueId + ") on element leagueId.");
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteInt(this.ladderPosition);
      writer.WriteBoolean(this.endSeasonReward);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.seasonId = (uint) reader.ReadVarUhShort();
      if (this.seasonId < 0U)
        throw new Exception("Forbidden value (" + (object) this.seasonId + ") on element of GameRolePlayArenaLeagueRewardsMessage.seasonId.");
      this.leagueId = (uint) reader.ReadVarUhShort();
      if (this.leagueId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leagueId + ") on element of GameRolePlayArenaLeagueRewardsMessage.leagueId.");
      this.ladderPosition = reader.ReadInt();
      this.endSeasonReward = reader.ReadBoolean();
    }
  }
}
