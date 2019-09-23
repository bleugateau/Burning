using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseBuyMessage : NetworkMessage
  {
    public const uint Id = 5804;
    public uint uid;
    public uint qty;
    public double price;

    public override uint MessageId
    {
      get
      {
        return 5804;
      }
    }

    public ExchangeBidHouseBuyMessage()
    {
    }

    public ExchangeBidHouseBuyMessage(uint uid, uint qty, double price)
    {
      this.uid = uid;
      this.qty = qty;
      this.price = price;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element uid.");
      writer.WriteVarInt((int) this.uid);
      if (this.qty < 0U)
        throw new Exception("Forbidden value (" + (object) this.qty + ") on element qty.");
      writer.WriteVarInt((int) this.qty);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.uid = reader.ReadVarUhInt();
      if (this.uid < 0U)
        throw new Exception("Forbidden value (" + (object) this.uid + ") on element of ExchangeBidHouseBuyMessage.uid.");
      this.qty = reader.ReadVarUhInt();
      if (this.qty < 0U)
        throw new Exception("Forbidden value (" + (object) this.qty + ") on element of ExchangeBidHouseBuyMessage.qty.");
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of ExchangeBidHouseBuyMessage.price.");
    }
  }
}
