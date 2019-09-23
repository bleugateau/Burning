using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
  {
    public const uint Id = 6578;
    public double goldSum;

    public override uint MessageId
    {
      get
      {
        return 6578;
      }
    }

    public ExchangeCraftPaymentModifiedMessage()
    {
    }

    public ExchangeCraftPaymentModifiedMessage(double goldSum)
    {
      this.goldSum = goldSum;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.goldSum < 0.0 || this.goldSum > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.goldSum + ") on element goldSum.");
      writer.WriteVarLong((long) this.goldSum);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.goldSum = (double) reader.ReadVarUhLong();
      if (this.goldSum < 0.0 || this.goldSum > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.goldSum + ") on element of ExchangeCraftPaymentModifiedMessage.goldSum.");
    }
  }
}
