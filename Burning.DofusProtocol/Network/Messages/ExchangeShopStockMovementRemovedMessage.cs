using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
  {
    public const uint Id = 5907;
    public uint objectId;

    public override uint MessageId
    {
      get
      {
        return 5907;
      }
    }

    public ExchangeShopStockMovementRemovedMessage()
    {
    }

    public ExchangeShopStockMovementRemovedMessage(uint objectId)
    {
      this.objectId = objectId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectId + ") on element objectId.");
      writer.WriteVarInt((int) this.objectId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectId = reader.ReadVarUhInt();
      if (this.objectId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectId + ") on element of ExchangeShopStockMovementRemovedMessage.objectId.");
    }
  }
}
