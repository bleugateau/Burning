using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceGuildLeavingMessage : NetworkMessage
  {
    public const uint Id = 6399;
    public bool kicked;
    public uint guildId;

    public override uint MessageId
    {
      get
      {
        return 6399;
      }
    }

    public AllianceGuildLeavingMessage()
    {
    }

    public AllianceGuildLeavingMessage(bool kicked, uint guildId)
    {
      this.kicked = kicked;
      this.guildId = guildId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.kicked);
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.kicked = reader.ReadBoolean();
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of AllianceGuildLeavingMessage.guildId.");
    }
  }
}
