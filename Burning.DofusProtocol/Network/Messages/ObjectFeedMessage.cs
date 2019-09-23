using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectFeedMessage : NetworkMessage
  {
    public List<ObjectItemQuantity> meal = new List<ObjectItemQuantity>();
    public const uint Id = 6290;
    public uint objectUID;

    public override uint MessageId
    {
      get
      {
        return 6290;
      }
    }

    public ObjectFeedMessage()
    {
    }

    public ObjectFeedMessage(uint objectUID, List<ObjectItemQuantity> meal)
    {
      this.objectUID = objectUID;
      this.meal = meal;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteShort((short) this.meal.Count);
      for (int index = 0; index < this.meal.Count; ++index)
        this.meal[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectFeedMessage.objectUID.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectItemQuantity objectItemQuantity = new ObjectItemQuantity();
        objectItemQuantity.Deserialize(reader);
        this.meal.Add(objectItemQuantity);
      }
    }
  }
}
