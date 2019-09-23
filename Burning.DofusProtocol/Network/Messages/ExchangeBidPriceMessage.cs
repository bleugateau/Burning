using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidPriceMessage : NetworkMessage
  {
    public const uint Id = 5755;
    public uint genericId;
    public double averagePrice;

    public override uint MessageId
    {
      get
      {
        return 5755;
      }
    }

    public ExchangeBidPriceMessage()
    {
    }

    public ExchangeBidPriceMessage(uint genericId, double averagePrice)
    {
      this.genericId = genericId;
      this.averagePrice = averagePrice;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.genericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genericId + ") on element genericId.");
      writer.WriteVarShort((short) this.genericId);
      if (this.averagePrice < -9.00719925474099E+15 || this.averagePrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.averagePrice + ") on element averagePrice.");
      writer.WriteVarLong((long) this.averagePrice);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.genericId = (uint) reader.ReadVarUhShort();
      if (this.genericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genericId + ") on element of ExchangeBidPriceMessage.genericId.");
      this.averagePrice = (double) reader.ReadVarLong();
      if (this.averagePrice < -9.00719925474099E+15 || this.averagePrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.averagePrice + ") on element of ExchangeBidPriceMessage.averagePrice.");
    }
  }
}
