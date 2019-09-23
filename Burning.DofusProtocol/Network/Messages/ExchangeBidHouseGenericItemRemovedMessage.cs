using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
  {
    public const uint Id = 5948;
    public uint objGenericId;

    public override uint MessageId
    {
      get
      {
        return 5948;
      }
    }

    public ExchangeBidHouseGenericItemRemovedMessage()
    {
    }

    public ExchangeBidHouseGenericItemRemovedMessage(uint objGenericId)
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
        throw new Exception("Forbidden value (" + (object) this.objGenericId + ") on element of ExchangeBidHouseGenericItemRemovedMessage.objGenericId.");
    }
  }
}
