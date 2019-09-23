using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FriendOnlineInformations : FriendInformations
  {
    public new const uint Id = 92;
    public double playerId;
    public string playerName;
    public uint level;
    public int alignmentSide;
    public int breed;
    public bool sex;
    public GuildInformations guildInfo;
    public uint moodSmileyId;
    public PlayerStatus status;
    public bool havenBagShared;

    public override uint TypeId
    {
      get
      {
        return 92;
      }
    }

    public FriendOnlineInformations()
    {
    }

    public FriendOnlineInformations(
      uint accountId,
      string accountName,
      uint playerState,
      uint lastConnection,
      int achievementPoints,
      int leagueId,
      int ladderPosition,
      double playerId,
      string playerName,
      uint level,
      int alignmentSide,
      int breed,
      bool sex,
      GuildInformations guildInfo,
      uint moodSmileyId,
      PlayerStatus status,
      bool havenBagShared)
      : base(accountId, accountName, playerState, lastConnection, achievementPoints, leagueId, ladderPosition)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.level = level;
      this.alignmentSide = alignmentSide;
      this.breed = breed;
      this.sex = sex;
      this.guildInfo = guildInfo;
      this.moodSmileyId = moodSmileyId;
      this.status = status;
      this.havenBagShared = havenBagShared;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.sex), (byte) 1, this.havenBagShared);
      writer.WriteByte((byte) num);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      writer.WriteByte((byte) this.alignmentSide);
      writer.WriteByte((byte) this.breed);
      this.guildInfo.Serialize(writer);
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element moodSmileyId.");
      writer.WriteVarShort((short) this.moodSmileyId);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.sex = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.havenBagShared = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of FriendOnlineInformations.playerId.");
      this.playerName = reader.ReadUTF();
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FriendOnlineInformations.level.");
      this.alignmentSide = (int) reader.ReadByte();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of FriendOnlineInformations.breed.");
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
      this.moodSmileyId = (uint) reader.ReadVarUhShort();
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element of FriendOnlineInformations.moodSmileyId.");
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
