using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectAddedMessage : NetworkMessage
  {
    public const uint Id = 3025;
    public ObjectItem @object;
    public uint origin;

    public override uint MessageId
    {
      get
      {
        return 3025;
      }
    }

    public ObjectAddedMessage()
    {
    }

    public ObjectAddedMessage(ObjectItem @object, uint origin)
    {
      this.@object = @object;
      this.origin = origin;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.@object.Serialize(writer);
      writer.WriteByte((byte) this.origin);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.@object = new ObjectItem();
      this.@object.Deserialize(reader);
      this.origin = (uint) reader.ReadByte();
      if (this.origin < 0U)
        throw new Exception("Forbidden value (" + (object) this.origin + ") on element of ObjectAddedMessage.origin.");
    }
  }
}
