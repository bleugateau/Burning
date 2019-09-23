using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFactsErrorMessage : NetworkMessage
  {
    public const uint Id = 6424;
    public uint guildId;

    public override uint MessageId
    {
      get
      {
        return 6424;
      }
    }

    public GuildFactsErrorMessage()
    {
    }

    public GuildFactsErrorMessage(uint guildId)
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
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of GuildFactsErrorMessage.guildId.");
    }
  }
}
