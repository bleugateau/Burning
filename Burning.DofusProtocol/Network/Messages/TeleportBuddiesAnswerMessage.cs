using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportBuddiesAnswerMessage : NetworkMessage
  {
    public const uint Id = 6294;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6294;
      }
    }

    public TeleportBuddiesAnswerMessage()
    {
    }

    public TeleportBuddiesAnswerMessage(bool accept)
    {
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.accept = reader.ReadBoolean();
    }
  }
}
