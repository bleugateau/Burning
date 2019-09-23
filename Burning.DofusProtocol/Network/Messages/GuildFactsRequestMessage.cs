using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFactsRequestMessage : NetworkMessage
  {
    public const uint Id = 6404;
    public uint guildId;

    public override uint MessageId
    {
      get
      {
        return 6404;
      }
    }

    public GuildFactsRequestMessage()
    {
    }

    public GuildFactsRequestMessage(uint guildId)
    {
      this.guildId = guildId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of GuildFactsRequestMessage.guildId.");
    }
  }
}
