using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MimicryObjectPreviewMessage : NetworkMessage
  {
    public const uint Id = 6458;
    public ObjectItem result;

    public override uint MessageId
    {
      get
      {
        return 6458;
      }
    }

    public MimicryObjectPreviewMessage()
    {
    }

    public MimicryObjectPreviewMessage(ObjectItem result)
    {
      this.result = result;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.result.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.result = new ObjectItem();
      this.result.Deserialize(reader);
    }
  }
}
