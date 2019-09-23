using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockSellRequestMessage : NetworkMessage
  {
    public const uint Id = 5953;
    public double price;
    public bool forSale;

    public override uint MessageId
    {
      get
      {
        return 5953;
      }
    }

    public PaddockSellRequestMessage()
    {
    }

    public PaddockSellRequestMessage(double price, bool forSale)
    {
      this.price = price;
      this.forSale = forSale;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element price.");
      writer.WriteVarLong((long) this.price);
      writer.WriteBoolean(this.forSale);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.price = (double) reader.ReadVarUhLong();
      if (this.price < 0.0 || this.price > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.price + ") on element of PaddockSellRequestMessage.price.");
      this.forSale = reader.ReadBoolean();
    }
  }
}
