using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectModifiedMessage : NetworkMessage
  {
    public const uint Id = 3029;
    public ObjectItem @object;

    public override uint MessageId
    {
      get
      {
        return 3029;
      }
    }

    public ObjectModifiedMessage()
    {
    }

    public ObjectModifiedMessage(ObjectItem @object)
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
