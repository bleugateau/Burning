using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PaddockBuyResultMessage : NetworkMessage
  {
    public const uint Id = 6516;
    public double paddockId;
    public bool bought;
    public double realPrice;

    public override uint MessageId
    {
      get
      {
        return 6516;
      }
    }

    public PaddockBuyResultMessage()
    {
    }

    public PaddockBuyResultMessage(double paddockId, bool bought, double realPrice)
    {
      this.paddockId = paddockId;
      this.bought = bought;
      this.realPrice = realPrice;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element paddockId.");
      writer.WriteDouble(this.paddockId);
      writer.WriteBoolean(this.bought);
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element realPrice.");
      writer.WriteVarLong((long) this.realPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.paddockId = reader.ReadDouble();
      if (this.paddockId < 0.0 || this.paddockId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.paddockId + ") on element of PaddockBuyResultMessage.paddockId.");
      this.bought = reader.ReadBoolean();
      this.realPrice = (double) reader.ReadVarUhLong();
      if (this.realPrice < 0.0 || this.realPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.realPrice + ") on element of PaddockBuyResultMessage.realPrice.");
    }
  }
}
