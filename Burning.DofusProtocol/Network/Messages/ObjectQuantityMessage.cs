using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectQuantityMessage : NetworkMessage
  {
    public const uint Id = 3023;
    public uint objectUID;
    public uint quantity;
    public uint origin;

    public override uint MessageId
    {
      get
      {
        return 3023;
      }
    }

    public ObjectQuantityMessage()
    {
    }

    public ObjectQuantityMessage(uint objectUID, uint quantity, uint origin)
    {
      this.objectUID = objectUID;
      this.quantity = quantity;
      this.origin = origin;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
      writer.WriteByte((byte) this.origin);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectQuantityMessage.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectQuantityMessage.quantity.");
      this.origin = (uint) reader.ReadByte();
      if (this.origin < 0U)
        throw new Exception("Forbidden value (" + (object) this.origin + ") on element of ObjectQuantityMessage.origin.");
    }
  }
}
