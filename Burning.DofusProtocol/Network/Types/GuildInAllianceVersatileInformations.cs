using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GuildInAllianceVersatileInformations : GuildVersatileInformations
  {
    public new const uint Id = 437;
    public uint allianceId;

    public override uint TypeId
    {
      get
      {
        return 437;
      }
    }

    public GuildInAllianceVersatileInformations()
    {
    }

    public GuildInAllianceVersatileInformations(
      uint guildId,
      double leaderId,
      uint guildLevel,
      uint nbMembers,
      uint allianceId)
      : base(guildId, leaderId, guildLevel, nbMembers)
    {
      this.allianceId = allianceId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of GuildInAllianceVersatileInformations.allianceId.");
    }
  }
}
