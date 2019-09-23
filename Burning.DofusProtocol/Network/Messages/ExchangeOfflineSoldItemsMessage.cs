using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeOfflineSoldItemsMessage : NetworkMessage
  {
    public List<ObjectItemGenericQuantityPrice> bidHouseItems = new List<ObjectItemGenericQuantityPrice>();
    public List<ObjectItemGenericQuantityPrice> merchantItems = new List<ObjectItemGenericQuantityPrice>();
    public const uint Id = 6613;

    public override uint MessageId
    {
      get
      {
        return 6613;
      }
    }

    public ExchangeOfflineSoldItemsMessage()
    {
    }

    public ExchangeOfflineSoldItemsMessage(
      List<ObjectItemGenericQuantityPrice> bidHouseItems,
      List<ObjectItemGenericQuantityPrice> merchantItems)
    {
      this.bidHouseItems = bidHouseItems;
      this.merchantItems = merchantItems;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.bidHouseItems.Count);
      for (int index = 0; index < this.bidHouseItems.Count; ++index)
        this.bidHouseItems[index].Serialize(writer);
      writer.WriteShort((short) this.merchantItems.Count);
      for (int index = 0; index < this.merchantItems.Count; ++index)
        this.merchantItems[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        ObjectItemGenericQuantityPrice genericQuantityPrice = new ObjectItemGenericQuantityPrice();
        genericQuantityPrice.Deserialize(reader);
        this.bidHouseItems.Add(genericQuantityPrice);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        ObjectItemGenericQuantityPrice genericQuantityPrice = new ObjectItemGenericQuantityPrice();
        genericQuantityPrice.Deserialize(reader);
        this.merchantItems.Add(genericQuantityPrice);
      }
    }
  }
}
