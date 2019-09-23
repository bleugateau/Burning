using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveElementUpdatedMessage : NetworkMessage
  {
    public const uint Id = 5708;
    public InteractiveElement interactiveElement;

    public override uint MessageId
    {
      get
      {
        return 5708;
      }
    }

    public InteractiveElementUpdatedMessage()
    {
    }

    public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
    {
      this.interactiveElement = interactiveElement;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.interactiveElement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.interactiveElement = new InteractiveElement();
      this.interactiveElement.Deserialize(reader);
    }
  }
}
