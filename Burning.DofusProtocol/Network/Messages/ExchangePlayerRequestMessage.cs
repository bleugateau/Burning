using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangePlayerRequestMessage : ExchangeRequestMessage
  {
    public new const uint Id = 5773;
    public double target;

    public override uint MessageId
    {
      get
      {
        return 5773;
      }
    }

    public ExchangePlayerRequestMessage()
    {
    }

    public ExchangePlayerRequestMessage(int exchangeType, double target)
      : base(exchangeType)
    {
      this.target = target;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element target.");
      writer.WriteVarLong((long) this.target);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.target = (double) reader.ReadVarUhLong();
      if (this.target < 0.0 || this.target > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.target + ") on element of ExchangePlayerRequestMessage.target.");
    }
  }
}
