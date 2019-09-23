using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseGuildNoneMessage : NetworkMessage
  {
    public const uint Id = 5701;
    public uint houseId;
    public uint instanceId;
    public bool secondHand;

    public override uint MessageId
    {
      get
      {
        return 5701;
      }
    }

    public HouseGuildNoneMessage()
    {
    }

    public HouseGuildNoneMessage(uint houseId, uint instanceId, bool secondHand)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.secondHand = secondHand;
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
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseGuildNoneMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseGuildNoneMessage.instanceId.");
      this.secondHand = reader.ReadBoolean();
    }
  }
}
