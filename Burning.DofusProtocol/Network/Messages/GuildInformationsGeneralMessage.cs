using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInformationsGeneralMessage : NetworkMessage
  {
    public const uint Id = 5557;
    public bool abandonnedPaddock;
    public uint level;
    public double expLevelFloor;
    public double experience;
    public double expNextLevelFloor;
    public uint creationDate;
    public uint nbTotalMembers;
    public uint nbConnectedMembers;

    public override uint MessageId
    {
      get
      {
        return 5557;
      }
    }

    public GuildInformationsGeneralMessage()
    {
    }

    public GuildInformationsGeneralMessage(
      bool abandonnedPaddock,
      uint level,
      double expLevelFloor,
      double experience,
      double expNextLevelFloor,
      uint creationDate,
      uint nbTotalMembers,
      uint nbConnectedMembers)
    {
      this.abandonnedPaddock = abandonnedPaddock;
      this.level = level;
      this.expLevelFloor = expLevelFloor;
      this.experience = experience;
      this.expNextLevelFloor = expNextLevelFloor;
      this.creationDate = creationDate;
      this.nbTotalMembers = nbTotalMembers;
      this.nbConnectedMembers = nbConnectedMembers;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.abandonnedPaddock);
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
      if (this.expLevelFloor < 0.0 || this.expLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expLevelFloor + ") on element expLevelFloor.");
      writer.WriteVarLong((long) this.expLevelFloor);
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarLong((long) this.experience);
      if (this.expNextLevelFloor < 0.0 || this.expNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expNextLevelFloor + ") on element expNextLevelFloor.");
      writer.WriteVarLong((long) this.expNextLevelFloor);
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element creationDate.");
      writer.WriteInt((int) this.creationDate);
      if (this.nbTotalMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTotalMembers + ") on element nbTotalMembers.");
      writer.WriteVarShort((short) this.nbTotalMembers);
      if (this.nbConnectedMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbConnectedMembers + ") on element nbConnectedMembers.");
      writer.WriteVarShort((short) this.nbConnectedMembers);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.abandonnedPaddock = reader.ReadBoolean();
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of GuildInformationsGeneralMessage.level.");
      this.expLevelFloor = (double) reader.ReadVarUhLong();
      if (this.expLevelFloor < 0.0 || this.expLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expLevelFloor + ") on element of GuildInformationsGeneralMessage.expLevelFloor.");
      this.experience = (double) reader.ReadVarUhLong();
      if (this.experience < 0.0 || this.experience > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of GuildInformationsGeneralMessage.experience.");
      this.expNextLevelFloor = (double) reader.ReadVarUhLong();
      if (this.expNextLevelFloor < 0.0 || this.expNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.expNextLevelFloor + ") on element of GuildInformationsGeneralMessage.expNextLevelFloor.");
      this.creationDate = (uint) reader.ReadInt();
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element of GuildInformationsGeneralMessage.creationDate.");
      this.nbTotalMembers = (uint) reader.ReadVarUhShort();
      if (this.nbTotalMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTotalMembers + ") on element of GuildInformationsGeneralMessage.nbTotalMembers.");
      this.nbConnectedMembers = (uint) reader.ReadVarUhShort();
      if (this.nbConnectedMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbConnectedMembers + ") on element of GuildInformationsGeneralMessage.nbConnectedMembers.");
    }
  }
}
