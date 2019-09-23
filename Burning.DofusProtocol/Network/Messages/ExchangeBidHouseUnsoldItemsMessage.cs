using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
  {
    public List<ObjectItemGenericQuantity> items = new List<ObjectItemGenericQuantity>();
    public const uint Id = 6612;

    public override uint MessageId
    {
      get
      {
        return 6612;
      }
    }

    public ExchangeBidHouseUnsoldItemsMessage()
    {
    }

    public ExchangeBidHouseUnsoldItemsMessage(List<ObjectItemGenericQuantity> items)
    {
      this.items = items;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.items.Count);
      for (int index = 0; index < this.items.Count; ++index)
        this.items[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemGenericQuantity itemGenericQuantity = new ObjectItemGenericQuantity();
        itemGenericQuantity.Deserialize(reader);
        this.items.Add(itemGenericQuantity);
      }
    }
  }
}
