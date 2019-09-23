using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildMember : CharacterMinimalInformations
  {
    public new const uint Id = 88;
    public int breed;
    public bool sex;
    public uint rank;
    public double givenExperience;
    public uint experienceGivenPercent;
    public uint rights;
    public uint connected;
    public int alignmentSide;
    public uint hoursSinceLastConnection;
    public uint moodSmileyId;
    public uint accountId;
    public int achievementPoints;
    public PlayerStatus status;
    public bool havenBagShared;

    public override uint TypeId
    {
      get
      {
        return 88;
      }
    }

    public GuildMember()
    {
    }

    public GuildMember(
      double id,
      string name,
      uint level,
      int breed,
      bool sex,
      uint rank,
      double givenExperience,
      uint experienceGivenPercent,
      uint rights,
      uint connected,
      int alignmentSide,
      uint hoursSinceLastConnection,
      uint moodSmileyId,
      uint accountId,
      int achievementPoints,
      PlayerStatus status,
      bool havenBagShared)
      : base(id, name, level)
    {
      this.breed = breed;
      this.sex = sex;
      this.rank = rank;
      this.givenExperience = givenExperience;
      this.experienceGivenPercent = experienceGivenPercent;
      this.rights = rights;
      this.connected = connected;
      this.alignmentSide = alignmentSide;
      this.hoursSinceLastConnection = hoursSinceLastConnection;
      this.moodSmileyId = moodSmileyId;
      this.accountId = accountId;
      this.achievementPoints = achievementPoints;
      this.status = status;
      this.havenBagShared = havenBagShared;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.sex), (byte) 1, this.havenBagShared);
      writer.WriteByte((byte) num);
      writer.WriteByte((byte) this.breed);
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element rank.");
      writer.WriteVarShort((short) this.rank);
      if (this.givenExperience < 0.0 || this.givenExperience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.givenExperience + ") on element givenExperience.");
      writer.WriteVarLong((long) this.givenExperience);
      if (this.experienceGivenPercent < 0U || this.experienceGivenPercent > 100U)
        throw new Exception("Forbidden value (" + (object) this.experienceGivenPercent + ") on element experienceGivenPercent.");
      writer.WriteByte((byte) this.experienceGivenPercent);
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element rights.");
      writer.WriteVarInt((int) this.rights);
      writer.WriteByte((byte) this.connected);
      writer.WriteByte((byte) this.alignmentSide);
      if (this.hoursSinceLastConnection < 0U || this.hoursSinceLastConnection > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hoursSinceLastConnection + ") on element hoursSinceLastConnection.");
      writer.WriteShort((short) this.hoursSinceLastConnection);
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element moodSmileyId.");
      writer.WriteVarShort((short) this.moodSmileyId);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      writer.WriteInt(this.achievementPoints);
      writer.WriteShort((short) this.status.TypeId);
      this.status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.sex = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.havenBagShared = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.breed = (int) reader.ReadByte();
      this.rank = (uint) reader.ReadVarUhShort();
      if (this.rank < 0U)
        throw new Exception("Forbidden value (" + (object) this.rank + ") on element of GuildMember.rank.");
      this.givenExperience = (double) reader.ReadVarUhLong();
      if (this.givenExperience < 0.0 || this.givenExperience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.givenExperience + ") on element of GuildMember.givenExperience.");
      this.experienceGivenPercent = (uint) reader.ReadByte();
      if (this.experienceGivenPercent < 0U || this.experienceGivenPercent > 100U)
        throw new Exception("Forbidden value (" + (object) this.experienceGivenPercent + ") on element of GuildMember.experienceGivenPercent.");
      this.rights = reader.ReadVarUhInt();
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element of GuildMember.rights.");
      this.connected = (uint) reader.ReadByte();
      if (this.connected < 0U)
        throw new Exception("Forbidden value (" + (object) this.connected + ") on element of GuildMember.connected.");
      this.alignmentSide = (int) reader.ReadByte();
      this.hoursSinceLastConnection = (uint) reader.ReadUShort();
      if (this.hoursSinceLastConnection < 0U || this.hoursSinceLastConnection > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.hoursSinceLastConnection + ") on element of GuildMember.hoursSinceLastConnection.");
      this.moodSmileyId = (uint) reader.ReadVarUhShort();
      if (this.moodSmileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.moodSmileyId + ") on element of GuildMember.moodSmileyId.");
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of GuildMember.accountId.");
      this.achievementPoints = reader.ReadInt();
      this.status = ProtocolTypeManager.GetInstance<PlayerStatus>((uint) reader.ReadUShort());
      this.status.Deserialize(reader);
    }
  }
}
