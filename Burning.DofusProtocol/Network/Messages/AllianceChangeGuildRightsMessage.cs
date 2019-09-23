using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceChangeGuildRightsMessage : NetworkMessage
  {
    public const uint Id = 6426;
    public uint guildId;
    public uint rights;

    public override uint MessageId
    {
      get
      {
        return 6426;
      }
    }

    public AllianceChangeGuildRightsMessage()
    {
    }

    public AllianceChangeGuildRightsMessage(uint guildId, uint rights)
    {
      this.guildId = guildId;
      this.rights = rights;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element guildId.");
      writer.WriteVarInt((int) this.guildId);
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element rights.");
      writer.WriteByte((byte) this.rights);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guildId = reader.ReadVarUhInt();
      if (this.guildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.guildId + ") on element of AllianceChangeGuildRightsMessage.guildId.");
      this.rights = (uint) reader.ReadByte();
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element of AllianceChangeGuildRightsMessage.rights.");
    }
  }
}
