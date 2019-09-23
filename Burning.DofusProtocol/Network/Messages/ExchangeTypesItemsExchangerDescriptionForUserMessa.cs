using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
  {
    public List<BidExchangerObjectInfo> itemTypeDescriptions = new List<BidExchangerObjectInfo>();
    public const uint Id = 5752;

    public override uint MessageId
    {
      get
      {
        return 5752;
      }
    }

    public ExchangeTypesItemsExchangerDescriptionForUserMessage()
    {
    }

    public ExchangeTypesItemsExchangerDescriptionForUserMessage(
      List<BidExchangerObjectInfo> itemTypeDescriptions)
    {
      this.itemTypeDescriptions = itemTypeDescriptions;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.itemTypeDescriptions.Count);
      for (int index = 0; index < this.itemTypeDescriptions.Count; ++index)
        this.itemTypeDescriptions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        BidExchangerObjectInfo exchangerObjectInfo = new BidExchangerObjectInfo();
        exchangerObjectInfo.Deserialize(reader);
        this.itemTypeDescriptions.Add(exchangerObjectInfo);
      }
    }
  }
}
