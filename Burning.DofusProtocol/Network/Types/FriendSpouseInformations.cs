using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FriendSpouseInformations
  {
    public const uint Id = 77;
    public uint spouseAccountId;
    public double spouseId;
    public string spouseName;
    public uint spouseLevel;
    public int breed;
    public int sex;
    public EntityLook spouseEntityLook;
    public GuildInformations guildInfo;
    public int alignmentSide;

    public virtual uint TypeId
    {
      get
      {
        return 77;
      }
    }

    public FriendSpouseInformations()
    {
    }

    public FriendSpouseInformations(
      uint spouseAccountId,
      double spouseId,
      string spouseName,
      uint spouseLevel,
      int breed,
      int sex,
      EntityLook spouseEntityLook,
      GuildInformations guildInfo,
      int alignmentSide)
    {
      this.spouseAccountId = spouseAccountId;
      this.spouseId = spouseId;
      this.spouseName = spouseName;
      this.spouseLevel = spouseLevel;
      this.breed = breed;
      this.sex = sex;
      this.spouseEntityLook = spouseEntityLook;
      this.guildInfo = guildInfo;
      this.alignmentSide = alignmentSide;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.spouseAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spouseAccountId + ") on element spouseAccountId.");
      writer.WriteInt((int) this.spouseAccountId);
      if (this.spouseId < 0.0 || this.spouseId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.spouseId + ") on element spouseId.");
      writer.WriteVarLong((long) this.spouseId);
      writer.WriteUTF(this.spouseName);
      if (this.spouseLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.spouseLevel + ") on element spouseLevel.");
      writer.WriteVarShort((short) this.spouseLevel);
      writer.WriteByte((byte) this.breed);
      writer.WriteByte((byte) this.sex);
      this.spouseEntityLook.Serialize(writer);
      this.guildInfo.Serialize(writer);
      writer.WriteByte((byte) this.alignmentSide);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.spouseAccountId = (uint) reader.ReadInt();
      if (this.spouseAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spouseAccountId + ") on element of FriendSpouseInformations.spouseAccountId.");
      this.spouseId = (double) reader.ReadVarUhLong();
      if (this.spouseId < 0.0 || this.spouseId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.spouseId + ") on element of FriendSpouseInformations.spouseId.");
      this.spouseName = reader.ReadUTF();
      this.spouseLevel = (uint) reader.ReadVarUhShort();
      if (this.spouseLevel < 0U)
        throw new Exception("Forbidden value (" + (object) this.spouseLevel + ") on element of FriendSpouseInformations.spouseLevel.");
      this.breed = (int) reader.ReadByte();
      this.sex = (int) reader.ReadByte();
      this.spouseEntityLook = new EntityLook();
      this.spouseEntityLook.Deserialize(reader);
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
      this.alignmentSide = (int) reader.ReadByte();
    }
  }
}
