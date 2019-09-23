using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FriendInformations : AbstractContactInformations
  {
    public new const uint Id = 78;
    public uint playerState;
    public uint lastConnection;
    public int achievementPoints;
    public int leagueId;
    public int ladderPosition;

    public override uint TypeId
    {
      get
      {
        return 78;
      }
    }

    public FriendInformations()
    {
    }

    public FriendInformations(
      uint accountId,
      string accountName,
      uint playerState,
      uint lastConnection,
      int achievementPoints,
      int leagueId,
      int ladderPosition)
      : base(accountId, accountName)
    {
      this.playerState = playerState;
      this.lastConnection = lastConnection;
      this.achievementPoints = achievementPoints;
      this.leagueId = leagueId;
      this.ladderPosition = ladderPosition;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.playerState);
      if (this.lastConnection < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastConnection + ") on element lastConnection.");
      writer.WriteVarShort((short) this.lastConnection);
      writer.WriteInt(this.achievementPoints);
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteInt(this.ladderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerState = (uint) reader.ReadByte();
      if (this.playerState < 0U)
        throw new Exception("Forbidden value (" + (object) this.playerState + ") on element of FriendInformations.playerState.");
      this.lastConnection = (uint) reader.ReadVarUhShort();
      if (this.lastConnection < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastConnection + ") on element of FriendInformations.lastConnection.");
      this.achievementPoints = reader.ReadInt();
      this.leagueId = (int) reader.ReadVarShort();
      this.ladderPosition = reader.ReadInt();
    }
  }
}
