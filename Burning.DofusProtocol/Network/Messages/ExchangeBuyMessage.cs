using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBuyMessage : NetworkMessage
  {
    public const uint Id = 5774;
    public uint objectToBuyId;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 5774;
      }
    }

    public ExchangeBuyMessage()
    {
    }

    public ExchangeBuyMessage(uint objectToBuyId, uint quantity)
    {
      this.objectToBuyId = objectToBuyId;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectToBuyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectToBuyId + ") on element objectToBuyId.");
      writer.WriteVarInt((int) this.objectToBuyId);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectToBuyId = reader.ReadVarUhInt();
      if (this.objectToBuyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectToBuyId + ") on element of ExchangeBuyMessage.objectToBuyId.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ExchangeBuyMessage.quantity.");
    }
  }
}
