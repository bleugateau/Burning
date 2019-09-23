using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeSellMessage : NetworkMessage
  {
    public const uint Id = 5778;
    public uint objectToSellId;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 5778;
      }
    }

    public ExchangeSellMessage()
    {
    }

    public ExchangeSellMessage(uint objectToSellId, uint quantity)
    {
      this.objectToSellId = objectToSellId;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectToSellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectToSellId + ") on element objectToSellId.");
      writer.WriteVarInt((int) this.objectToSellId);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectToSellId = reader.ReadVarUhInt();
      if (this.objectToSellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectToSellId + ") on element of ExchangeSellMessage.objectToSellId.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ExchangeSellMessage.quantity.");
    }
  }
}
