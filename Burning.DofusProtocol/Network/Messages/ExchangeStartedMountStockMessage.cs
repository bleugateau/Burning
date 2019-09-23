using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartedMountStockMessage : NetworkMessage
  {
    public List<ObjectItem> objectsInfos = new List<ObjectItem>();
    public const uint Id = 5984;

    public override uint MessageId
    {
      get
      {
        return 5984;
      }
    }

    public ExchangeStartedMountStockMessage()
    {
    }

    public ExchangeStartedMountStockMessage(List<ObjectItem> objectsInfos)
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
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.objectsInfos.Add(objectItem);
      }
    }
  }
}
