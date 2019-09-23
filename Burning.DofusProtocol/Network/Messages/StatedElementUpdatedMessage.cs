using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StatedElementUpdatedMessage : NetworkMessage
  {
    public const uint Id = 5709;
    public StatedElement statedElement;

    public override uint MessageId
    {
      get
      {
        return 5709;
      }
    }

    public StatedElementUpdatedMessage()
    {
    }

    public StatedElementUpdatedMessage(StatedElement statedElement)
    {
      this.statedElement = statedElement;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.statedElement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.statedElement = new StatedElement();
      this.statedElement.Deserialize(reader);
    }
  }
}
