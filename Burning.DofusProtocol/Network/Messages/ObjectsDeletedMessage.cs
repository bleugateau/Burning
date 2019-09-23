using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectsDeletedMessage : NetworkMessage
  {
    public List<uint> objectUID = new List<uint>();
    public const uint Id = 6034;

    public override uint MessageId
    {
      get
      {
        return 6034;
      }
    }

    public ObjectsDeletedMessage()
    {
    }

    public ObjectsDeletedMessage(List<uint> objectUID)
    {
      this.objectUID = objectUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectUID.Count);
      for (int index = 0; index < this.objectUID.Count; ++index)
      {
        if (this.objectUID[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.objectUID[index] + ") on element 1 (starting at 1) of objectUID.");
        writer.WriteVarInt((int) this.objectUID[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of objectUID.");
        this.objectUID.Add(num2);
      }
    }
  }
}
