using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseGuildRightsViewMessage : NetworkMessage
  {
    public const uint Id = 5700;
    public uint houseId;
    public uint instanceId;

    public override uint MessageId
    {
      get
      {
        return 5700;
      }
    }

    public HouseGuildRightsViewMessage()
    {
    }

    public HouseGuildRightsViewMessage(uint houseId, uint instanceId)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseGuildRightsViewMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseGuildRightsViewMessage.instanceId.");
    }
  }
}
