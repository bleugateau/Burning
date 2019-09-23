using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseTeleportRequestMessage : NetworkMessage
  {
    public const uint Id = 6726;
    public uint houseId;
    public uint houseInstanceId;

    public override uint MessageId
    {
      get
      {
        return 6726;
      }
    }

    public HouseTeleportRequestMessage()
    {
    }

    public HouseTeleportRequestMessage(uint houseId, uint houseInstanceId)
    {
      this.houseId = houseId;
      this.houseInstanceId = houseInstanceId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.houseInstanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseInstanceId + ") on element houseInstanceId.");
      writer.WriteInt((int) this.houseInstanceId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseTeleportRequestMessage.houseId.");
      this.houseInstanceId = (uint) reader.ReadInt();
      if (this.houseInstanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseInstanceId + ") on element of HouseTeleportRequestMessage.houseInstanceId.");
    }
  }
}
