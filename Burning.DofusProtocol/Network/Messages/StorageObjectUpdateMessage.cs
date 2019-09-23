using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StorageObjectUpdateMessage : NetworkMessage
  {
    public const uint Id = 5647;
    public ObjectItem @object;

    public override uint MessageId
    {
      get
      {
        return 5647;
      }
    }

    public StorageObjectUpdateMessage()
    {
    }

    public StorageObjectUpdateMessage(ObjectItem @object)
    {
      this.@object = @object;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.@object.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.@object = new ObjectItem();
      this.@object.Deserialize(reader);
    }
  }
}
