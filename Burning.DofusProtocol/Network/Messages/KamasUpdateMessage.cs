using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class KamasUpdateMessage : NetworkMessage
  {
    public const uint Id = 5537;
    public double kamasTotal;

    public override uint MessageId
    {
      get
      {
        return 5537;
      }
    }

    public KamasUpdateMessage()
    {
    }

    public KamasUpdateMessage(double kamasTotal)
    {
      this.kamasTotal = kamasTotal;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.kamasTotal < 0.0 || this.kamasTotal > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamasTotal + ") on element kamasTotal.");
      writer.WriteVarLong((long) this.kamasTotal);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.kamasTotal = (double) reader.ReadVarUhLong();
      if (this.kamasTotal < 0.0 || this.kamasTotal > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kamasTotal + ") on element of KamasUpdateMessage.kamasTotal.");
    }
  }
}
