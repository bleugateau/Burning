using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeShopStockStartedMessage : NetworkMessage
  {
    public List<ObjectItemToSell> objectsInfos = new List<ObjectItemToSell>();
    public const uint Id = 5910;

    public override uint MessageId
    {
      get
      {
        return 5910;
      }
    }

    public ExchangeShopStockStartedMessage()
    {
    }

    public ExchangeShopStockStartedMessage(List<ObjectItemToSell> objectsInfos)
    {
      this.objectsInfos = objectsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectsInfos.Count);
      for (int index = 0; index < this.objectsInfos.Count; ++index)
        this.objectsInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemToSell objectItemToSell = new ObjectItemToSell();
        objectItemToSell.Deserialize(reader);
        this.objectsInfos.Add(objectItemToSell);
      }
    }
  }
}
