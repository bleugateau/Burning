using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceJoinedMessage : NetworkMessage
  {
    public const uint Id = 6402;
    public AllianceInformations allianceInfo;
    public bool enabled;
    public uint leadingGuildId;

    public override uint MessageId
    {
      get
      {
        return 6402;
      }
    }

    public AllianceJoinedMessage()
    {
    }

    public AllianceJoinedMessage(
      AllianceInformations allianceInfo,
      bool enabled,
      uint leadingGuildId)
    {
      this.allianceInfo = allianceInfo;
      this.enabled = enabled;
      this.leadingGuildId = leadingGuildId;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.allianceInfo.Serialize(writer);
      writer.WriteBoolean(this.enabled);
      if (this.leadingGuildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leadingGuildId + ") on element leadingGuildId.");
      writer.WriteVarInt((int) this.leadingGuildId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allianceInfo = new AllianceInformations();
      this.allianceInfo.Deserialize(reader);
      this.enabled = reader.ReadBoolean();
      this.leadingGuildId = reader.ReadVarUhInt();
      if (this.leadingGuildId < 0U)
        throw new Exception("Forbidden value (" + (object) this.leadingGuildId + ") on element of AllianceJoinedMessage.leadingGuildId.");
    }
  }
}
