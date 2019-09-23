using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
  {
    public new const uint Id = 5521;
    public double quantity;

    public override uint MessageId
    {
      get
      {
        return 5521;
      }
    }

    public ExchangeKamaModifiedMessage()
    {
    }

    public ExchangeKamaModifiedMessage(bool remote, double quantity)
      : base(remote)
    {
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.quantity < 0.0 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarLong((long) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.quantity = (double) reader.ReadVarUhLong();
      if (this.quantity < 0.0 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ExchangeKamaModifiedMessage.quantity.");
    }
  }
}
