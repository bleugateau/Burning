using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
  {
    public List<double> minimalPrices = new List<double>();
    public new const uint Id = 6464;
    public bool allIdentical;

    public override uint MessageId
    {
      get
      {
        return 6464;
      }
    }

    public ExchangeBidPriceForSellerMessage()
    {
    }

    public ExchangeBidPriceForSellerMessage(
      uint genericId,
      double averagePrice,
      bool allIdentical,
      List<double> minimalPrices)
      : base(genericId, averagePrice)
    {
      this.allIdentical = allIdentical;
      this.minimalPrices = minimalPrices;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.allIdentical);
      writer.WriteShort((short) this.minimalPrices.Count);
      for (int index = 0; index < this.minimalPrices.Count; ++index)
      {
        if (this.minimalPrices[index] < 0.0 || this.minimalPrices[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.minimalPrices[index] + ") on element 2 (starting at 1) of minimalPrices.");
        writer.WriteVarLong((long) this.minimalPrices[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allIdentical = reader.ReadBoolean();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of minimalPrices.");
        this.minimalPrices.Add(num2);
      }
    }
  }
}
