using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseGenericItemAddedMessage : NetworkMessage
  {
    public const uint Id = 5947;
    public uint objGenericId;

    public override uint MessageId
    {
      get
      {
        return 5947;
      }
    }

    public ExchangeBidHouseGenericItemAddedMessage()
    {
    }

    public ExchangeBidHouseGenericItemAddedMessage(uint objGenericId)
    {
      this.objGenericId = objGenericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objGenericId + ") on element objGenericId.");
      writer.WriteVarShort((short) this.objGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objGenericId = (uint) reader.ReadVarUhShort();
      if (this.objGenericId < 0U)
        throw new Exception("Forbidden value (" + (object) this.objGenericId + ") on element of ExchangeBidHouseGenericItemAddedMessage.objGenericId.");
    }
  }
}
