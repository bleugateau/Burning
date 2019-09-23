using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
  {
    public new const uint Id = 5514;
    public double price;

    public override uint MessageId
    {
      get
      {
        return 5514;
      }
    }

    public ExchangeObjectMovePricedMessage()
    {
    }

    public ExchangeObjectMovePricedMessage(uint objectUID, int quantity, double price)
      : base(objectUID, quantity)
    {
      this.price = price;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of ExchangeObjectMovePricedMessage.price.");
    }
  }
}
