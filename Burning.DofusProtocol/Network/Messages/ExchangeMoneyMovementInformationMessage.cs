using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMoneyMovementInformationMessage : NetworkMessage
  {
    public const uint Id = 6834;
    public double limit;

    public override uint MessageId
    {
      get
      {
        return 6834;
      }
    }

    public ExchangeMoneyMovementInformationMessage()
    {
    }

    public ExchangeMoneyMovementInformationMessage(double limit)
    {
      this.limit = limit;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.limit < 0.0 || this.limit > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.limit + ") on element limit.");
      writer.WriteVarLong((long) this.limit);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.limit = (double) reader.ReadVarUhLong();
      if (this.limit < 0.0 || this.limit > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.limit + ") on element of ExchangeMoneyMovementInformationMessage.limit.");
    }
  }
}
