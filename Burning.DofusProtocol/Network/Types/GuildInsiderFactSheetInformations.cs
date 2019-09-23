using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
  {
    public new const uint Id = 423;
    public string leaderName;
    public uint nbConnectedMembers;
    public uint nbTaxCollectors;
    public uint lastActivity;

    public override uint TypeId
    {
      get
      {
        return 423;
      }
    }

    public GuildInsiderFactSheetInformations()
    {
    }

    public GuildInsiderFactSheetInformations(
      uint guildId,
      string guildName,
      uint guildLevel,
      GuildEmblem guildEmblem,
      double leaderId,
      uint nbMembers,
      string leaderName,
      uint nbConnectedMembers,
      uint nbTaxCollectors,
      uint lastActivity)
      : base(guildId, guildName, guildLevel, guildEmblem, leaderId, nbMembers)
    {
      this.leaderName = leaderName;
      this.nbConnectedMembers = nbConnectedMembers;
      this.nbTaxCollectors = nbTaxCollectors;
      this.lastActivity = lastActivity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.leaderName);
      if (this.nbConnectedMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbConnectedMembers + ") on element nbConnectedMembers.");
      writer.WriteVarShort((short) this.nbConnectedMembers);
      if (this.nbTaxCollectors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTaxCollectors + ") on element nbTaxCollectors.");
      writer.WriteByte((byte) this.nbTaxCollectors);
      if (this.lastActivity < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastActivity + ") on element lastActivity.");
      writer.WriteInt((int) this.lastActivity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.leaderName = reader.ReadUTF();
      this.nbConnectedMembers = (uint) reader.ReadVarUhShort();
      if (this.nbConnectedMembers < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbConnectedMembers + ") on element of GuildInsiderFactSheetInformations.nbConnectedMembers.");
      this.nbTaxCollectors = (uint) reader.ReadByte();
      if (this.nbTaxCollectors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTaxCollectors + ") on element of GuildInsiderFactSheetInformations.nbTaxCollectors.");
      this.lastActivity = (uint) reader.ReadInt();
      if (this.lastActivity < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastActivity + ") on element of GuildInsiderFactSheetInformations.lastActivity.");
    }
  }
}
