using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
  {
    public const uint Id = 6600;
    public uint percentToPrism;
    public uint percentToPlayer;

    public override uint MessageId
    {
      get
      {
        return 6600;
      }
    }

    public ExchangeStartOkRecycleTradeMessage()
    {
    }

    public ExchangeStartOkRecycleTradeMessage(uint percentToPrism, uint percentToPlayer)
    {
      this.percentToPrism = percentToPrism;
      this.percentToPlayer = percentToPlayer;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.percentToPrism < 0U)
        throw new Exception("Forbidden value (" + (object) this.percentToPrism + ") on element percentToPrism.");
      writer.WriteShort((short) this.percentToPrism);
      if (this.percentToPlayer < 0U)
        throw new Exception("Forbidden value (" + (object) this.percentToPlayer + ") on element percentToPlayer.");
      writer.WriteShort((short) this.percentToPlayer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.percentToPrism = (uint) reader.ReadShort();
      if (this.percentToPrism < 0U)
        throw new Exception("Forbidden value (" + (object) this.percentToPrism + ") on element of ExchangeStartOkRecycleTradeMessage.percentToPrism.");
      this.percentToPlayer = (uint) reader.ReadShort();
      if (this.percentToPlayer < 0U)
        throw new Exception("Forbidden value (" + (object) this.percentToPlayer + ") on element of ExchangeStartOkRecycleTradeMessage.percentToPlayer.");
    }
  }
}
