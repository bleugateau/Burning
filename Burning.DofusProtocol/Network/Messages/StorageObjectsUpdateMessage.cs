using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StorageObjectsUpdateMessage : NetworkMessage
  {
    public List<ObjectItem> objectList = new List<ObjectItem>();
    public const uint Id = 6036;

    public override uint MessageId
    {
      get
      {
        return 6036;
      }
    }

    public StorageObjectsUpdateMessage()
    {
    }

    public StorageObjectsUpdateMessage(List<ObjectItem> objectList)
    {
      this.objectList = objectList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectList.Count);
      for (int index = 0; index < this.objectList.Count; ++index)
        this.objectList[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItem objectItem = new ObjectItem();
        objectItem.Deserialize(reader);
        this.objectList.Add(objectItem);
      }
    }
  }
}
