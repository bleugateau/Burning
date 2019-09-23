using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeCraftPaymentModificationRequestMessage : NetworkMessage
  {
    public const uint Id = 6579;
    public double quantity;

    public override uint MessageId
    {
      get
      {
        return 6579;
      }
    }

    public ExchangeCraftPaymentModificationRequestMessage()
    {
    }

    public ExchangeCraftPaymentModificationRequestMessage(double quantity)
    {
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.quantity < 0.0 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarLong((long) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.quantity = (double) reader.ReadVarUhLong();
      if (this.quantity < 0.0 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ExchangeCraftPaymentModificationRequestMessage.quantity.");
    }
  }
}
