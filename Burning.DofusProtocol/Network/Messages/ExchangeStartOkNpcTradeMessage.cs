using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkNpcTradeMessage : NetworkMessage
  {
    public const uint Id = 5785;
    public double npcId;

    public override uint MessageId
    {
      get
      {
        return 5785;
      }
    }

    public ExchangeStartOkNpcTradeMessage()
    {
    }

    public ExchangeStartOkNpcTradeMessage(double npcId)
    {
      this.npcId = npcId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.npcId < -9.00719925474099E+15 || this.npcId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element npcId.");
      writer.WriteDouble(this.npcId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.npcId = reader.ReadDouble();
      if (this.npcId < -9.00719925474099E+15 || this.npcId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element of ExchangeStartOkNpcTradeMessage.npcId.");
    }
  }
}
