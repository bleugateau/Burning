using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectDeleteMessage : NetworkMessage
  {
    public const uint Id = 3022;
    public uint objectUID;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 3022;
      }
    }

    public ObjectDeleteMessage()
    {
    }

    public ObjectDeleteMessage(uint objectUID, uint quantity)
    {
      this.objectUID = objectUID;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectDeleteMessage.objectUID.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of ObjectDeleteMessage.quantity.");
    }
  }
}
