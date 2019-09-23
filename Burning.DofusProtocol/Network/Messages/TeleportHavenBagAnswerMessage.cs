using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TeleportHavenBagAnswerMessage : NetworkMessage
  {
    public const uint Id = 6646;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6646;
      }
    }

    public TeleportHavenBagAnswerMessage()
    {
    }

    public TeleportHavenBagAnswerMessage(bool accept)
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
