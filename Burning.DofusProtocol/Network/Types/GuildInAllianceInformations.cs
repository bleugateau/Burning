using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildInAllianceInformations : GuildInformations
  {
    public new const uint Id = 420;
    public uint nbMembers;
    public uint joinDate;

    public override uint TypeId
    {
      get
      {
        return 420;
      }
    }

    public GuildInAllianceInformations()
    {
    }

    public GuildInAllianceInformations(
      uint guildId,
      string guildName,
      uint guildLevel,
      GuildEmblem guildEmblem,
      uint nbMembers,
      uint joinDate)
      : base(guildId, guildName, guildLevel, guildEmblem)
    {
      this.nbMembers = nbMembers;
      this.joinDate = joinDate;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.nbMembers < 1U || this.nbMembers > 240U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element nbMembers.");
      writer.WriteByte((byte) this.nbMembers);
      if (this.joinDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.joinDate + ") on element joinDate.");
      writer.WriteInt((int) this.joinDate);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.nbMembers = (uint) reader.ReadByte();
      if (this.nbMembers < 1U || this.nbMembers > 240U)
        throw new Exception("Forbidden value (" + (object) this.nbMembers + ") on element of GuildInAllianceInformations.nbMembers.");
      this.joinDate = (uint) reader.ReadInt();
      if (this.joinDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.joinDate + ") on element of GuildInAllianceInformations.joinDate.");
    }
  }
}
