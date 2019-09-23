using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildJoinedMessage : NetworkMessage
  {
    public const uint Id = 5564;
    public GuildInformations guildInfo;
    public uint memberRights;

    public override uint MessageId
    {
      get
      {
        return 5564;
      }
    }

    public GuildJoinedMessage()
    {
    }

    public GuildJoinedMessage(GuildInformations guildInfo, uint memberRights)
    {
      this.guildInfo = guildInfo;
      this.memberRights = memberRights;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.guildInfo.Serialize(writer);
      if (this.memberRights < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberRights + ") on element memberRights.");
      writer.WriteVarInt((int) this.memberRights);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
      this.memberRights = reader.ReadVarUhInt();
      if (this.memberRights < 0U)
        throw new Exception("Forbidden value (" + (object) this.memberRights + ") on element of GuildJoinedMessage.memberRights.");
    }
  }
}
