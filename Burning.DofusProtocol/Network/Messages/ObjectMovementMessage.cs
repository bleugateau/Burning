using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectMovementMessage : NetworkMessage
  {
    public const uint Id = 3010;
    public uint objectUID;
    public uint position;

    public override uint MessageId
    {
      get
      {
        return 3010;
      }
    }

    public ObjectMovementMessage()
    {
    }

    public ObjectMovementMessage(uint objectUID, uint position)
    {
      this.objectUID = objectUID;
      this.position = position;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
      writer.WriteShort((short) this.position);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of ObjectMovementMessage.objectUID.");
      this.position = (uint) reader.ReadShort();
      if (this.position < 0U)
        throw new Exception("Forbidden value (" + (object) this.position + ") on element of ObjectMovementMessage.position.");
    }
  }
}
