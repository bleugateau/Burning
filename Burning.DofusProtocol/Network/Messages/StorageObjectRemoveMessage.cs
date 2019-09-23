using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StorageObjectRemoveMessage : NetworkMessage
  {
    public const uint Id = 5648;
    public uint objectUID;

    public override uint MessageId
    {
      get
      {
        return 5648;
      }
    }

    public StorageObjectRemoveMessage()
    {
    }

    public StorageObjectRemoveMessage(uint objectUID)
    {
      this.objectUID = objectUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element objectUID.");
      writer.WriteVarInt((int) this.objectUID);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectUID = reader.ReadVarUhInt();
      if (this.objectUID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectUID + ") on element of StorageObjectRemoveMessage.objectUID.");
    }
  }
}
