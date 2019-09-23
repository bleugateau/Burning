using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseGuildRightsMessage : NetworkMessage
  {
    public const uint Id = 5703;
    public uint houseId;
    public uint instanceId;
    public bool secondHand;
    public GuildInformations guildInfo;
    public uint rights;

    public override uint MessageId
    {
      get
      {
        return 5703;
      }
    }

    public HouseGuildRightsMessage()
    {
    }

    public HouseGuildRightsMessage(
      uint houseId,
      uint instanceId,
      bool secondHand,
      GuildInformations guildInfo,
      uint rights)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.secondHand = secondHand;
      this.guildInfo = guildInfo;
      this.rights = rights;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.secondHand);
      this.guildInfo.Serialize(writer);
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element rights.");
      writer.WriteVarInt((int) this.rights);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseGuildRightsMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseGuildRightsMessage.instanceId.");
      this.secondHand = reader.ReadBoolean();
      this.guildInfo = new GuildInformations();
      this.guildInfo.Deserialize(reader);
      this.rights = reader.ReadVarUhInt();
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element of HouseGuildRightsMessage.rights.");
    }
  }
}
