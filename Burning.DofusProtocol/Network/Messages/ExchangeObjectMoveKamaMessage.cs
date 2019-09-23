using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectMoveKamaMessage : NetworkMessage
  {
    public const uint Id = 5520;
    public double quantity;

    public override uint MessageId
    {
      get
      {
        return 5520;
      }
    }

    public ExchangeObjectMoveKamaMessage()
    {
    }

    public ExchangeObjectMoveKamaMessage(double quantity)
    {
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.quantity < -9.00719925474099E+15 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarLong((long) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.quantity = (double) reader.ReadVarLong();
      if (this.quantity < -9.00719925474099E+15 || this.quantity > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ExchangeObjectMoveKamaMessage.quantity.");
    }
  }
}
