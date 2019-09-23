using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectSetPositionMessage : NetworkMessage
  {
    public const uint Id = 3021;
    public uint objectUID;
    public uint position;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 3021;
      }
    }

    public ObjectSetPositionMessage()
    {
    }

    public ObjectSetPositionMessage(uint objectUID, uint position, uint quantity)
    {
      this.objectUID = objectUID;
      this.position = position;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteShort((short) this.position);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectSetPositionMessage.objectUID.");
      this.position = (uint) reader.ReadShort();
      if (this.position < 0U)
        throw new Exception("Forbidden value (" + (object) this.position + ") on element of ObjectSetPositionMessage.position.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectSetPositionMessage.quantity.");
    }
  }
}
