using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StorageObjectsRemoveMessage : NetworkMessage
  {
    public List<uint> objectUIDList = new List<uint>();
    public const uint Id = 6035;

    public override uint MessageId
    {
      get
      {
        return 6035;
      }
    }

    public StorageObjectsRemoveMessage()
    {
    }

    public StorageObjectsRemoveMessage(List<uint> objectUIDList)
    {
      this.objectUIDList = objectUIDList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectUIDList.Count);
      for (int index = 0; index < this.objectUIDList.Count; ++index)
      {
        if (this.objectUIDList[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.objectUIDList[index] + ") on element 1 (starting at 1) of objectUIDList.");
        writer.WriteVarInt((int) this.objectUIDList[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of objectUIDList.");
        this.objectUIDList.Add(num2);
      }
    }
  }
}
