using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildFactSheetInformations : GuildInformations
  {
    public new const uint Id = 424;
    public double leaderId;
    public uint nbMembers;

    public override uint TypeId
    {
      get
      {
        return 424;
      }
    }

    public GuildFactSheetInformations()
    {
    }

    public GuildFactSheetInformations(
      uint guildId,
      string guildName,
      uint guildLevel,
      GuildEmblem guildEmblem,
      double leaderId,
      uint nbMembers)
      : base(guildId, guildName, guildLevel, guildEmblem)
    {
      this.leaderId = leaderId;
      this.nbMembers = nbMembers;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element leaderId.");
      writer.WriteVarLong((long) this.leaderId);
      if (this.nbMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element nbMembers.");
      writer.WriteVarShort((short) this.nbMembers);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.leaderId = (double) reader.ReadVarUhLong();
      if (this.leaderId < 0.0 || this.leaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderId + ") on element of GuildFactSheetInformations.leaderId.");
      this.nbMembers = (uint) reader.ReadVarUhShort();
      if (this.nbMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element of GuildFactSheetInformations.nbMembers.");
    }
  }
}
