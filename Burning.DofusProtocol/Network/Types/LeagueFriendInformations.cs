using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class LeagueFriendInformations : AbstractContactInformations
  {
    public new const uint Id = 555;
    public double playerId;
    public string playerName;
    public int breed;
    public bool sex;
    public uint level;
    public int leagueId;
    public int totalLeaguePoints;
    public int ladderPosition;

    public override uint TypeId
    {
      get
      {
        return 555;
      }
    }

    public LeagueFriendInformations()
    {
    }

    public LeagueFriendInformations(
      uint accountId,
      string accountName,
      double playerId,
      string playerName,
      int breed,
      bool sex,
      uint level,
      int leagueId,
      int totalLeaguePoints,
      int ladderPosition)
      : base(accountId, accountName)
    {
      this.playerId = playerId;
      this.playerName = playerName;
      this.breed = breed;
      this.sex = sex;
      this.level = level;
      this.leagueId = leagueId;
      this.totalLeaguePoints = totalLeaguePoints;
      this.ladderPosition = ladderPosition;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      writer.WriteUTF(this.playerName);
      writer.WriteByte((byte) this.breed);
      writer.WriteBoolean(this.sex);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
      writer.WriteVarShort((short) this.leagueId);
      writer.WriteVarShort((short) this.totalLeaguePoints);
      writer.WriteInt(this.ladderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of LeagueFriendInformations.playerId.");
      this.playerName = reader.ReadUTF();
      this.breed = (int) reader.ReadByte();
      if (this.breed < 1 || this.breed > 18)
        throw new Exception("Forbidden value (" + (object) this.breed + ") on element of LeagueFriendInformations.breed.");
      this.sex = reader.ReadBoolean();
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of LeagueFriendInformations.level.");
      this.leagueId = (int) reader.ReadVarShort();
      this.totalLeaguePoints = (int) reader.ReadVarShort();
      this.ladderPosition = reader.ReadInt();
    }
  }
}
