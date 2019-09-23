using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectsQuantityMessage : NetworkMessage
  {
    public List<ObjectItemQuantity> objectsUIDAndQty = new List<ObjectItemQuantity>();
    public const uint Id = 6206;

    public override uint MessageId
    {
      get
      {
        return 6206;
      }
    }

    public ObjectsQuantityMessage()
    {
    }

    public ObjectsQuantityMessage(List<ObjectItemQuantity> objectsUIDAndQty)
    {
      this.objectsUIDAndQty = objectsUIDAndQty;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.objectsUIDAndQty.Count);
      for (int index = 0; index < this.objectsUIDAndQty.Count; ++index)
        this.objectsUIDAndQty[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemQuantity objectItemQuantity = new ObjectItemQuantity();
        objectItemQuantity.Deserialize(reader);
        this.objectsUIDAndQty.Add(objectItemQuantity);
      }
    }
  }
}
