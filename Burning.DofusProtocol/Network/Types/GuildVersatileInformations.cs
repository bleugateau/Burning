using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildVersatileInformations
  {
    public const uint Id = 435;
    public uint guildId;
    public double leaderId;
    public uint guildLevel;
    public uint nbMembers;

    public virtual uint TypeId
    {
      get
      {
        return 435;
      }
    }

    public GuildVersatileInformations()
    {
    }

    public GuildVersatileInformations(
      uint guildId,
      double leaderId,
      uint guildLevel,
      uint nbMembers)
    {
      this.guildId = guildId;
      this.leaderId = leaderId;
      this.guildLevel = guildLevel;
      this.nbMembers = nbMembers;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element leaderId.");
      writer.WriteVarLong((long) this.leaderId);
      if (this.guildLevel < 1U || this.guildLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element guildLevel.");
      writer.WriteByte((byte) this.guildLevel);
      if (this.nbMembers < 1U || this.nbMembers > 240U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element nbMembers.");
      writer.WriteByte((byte) this.nbMembers);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of GuildVersatileInformations.guildId.");
      this.leaderId = (double) reader.ReadVarUhLong();
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element of GuildVersatileInformations.leaderId.");
      this.guildLevel = (uint) reader.ReadByte();
      if (this.guildLevel < 1U || this.guildLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element of GuildVersatileInformations.guildLevel.");
      this.nbMembers = (uint) reader.ReadByte();
      if (this.nbMembers < 1U || this.nbMembers > 240U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element of GuildVersatileInformations.nbMembers.");
    }
  }
}
