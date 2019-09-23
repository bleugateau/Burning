using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHousePriceMessage : NetworkMessage
  {
    public const uint Id = 5805;
    public uint genId;

    public override uint MessageId
    {
      get
      {
        return 5805;
      }
    }

    public ExchangeBidHousePriceMessage()
    {
    }

    public ExchangeBidHousePriceMessage(uint genId)
    {
      this.genId = genId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.genId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genId + ") on element genId.");
      writer.WriteVarShort((short) this.genId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.genId = (uint) reader.ReadVarUhShort();
      if (this.genId < 0U)
        throw new Exception("Forbidden value (" + (object) this.genId + ") on element of ExchangeBidHousePriceMessage.genId.");
    }
  }
}
