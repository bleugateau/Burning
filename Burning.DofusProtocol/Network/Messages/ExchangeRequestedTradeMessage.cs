using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
  {
    public new const uint Id = 5523;
    public double source;
    public double target;

    public override uint MessageId
    {
      get
      {
        return 5523;
      }
    }

    public ExchangeRequestedTradeMessage()
    {
    }

    public ExchangeRequestedTradeMessage(int exchangeType, double source, double target)
      : base(exchangeType)
    {
      this.source = source;
      this.target = target;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.source < 0.0 || this.source > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.source + ") on element source.");
      writer.WriteVarLong((long) this.source);
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element target.");
      writer.WriteVarLong((long) this.target);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.source = (double) reader.ReadVarUhLong();
      if (this.source < 0.0 || this.source > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.source + ") on element of ExchangeRequestedTradeMessage.source.");
      this.target = (double) reader.ReadVarUhLong();
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element of ExchangeRequestedTradeMessage.target.");
    }
  }
}
