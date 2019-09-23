using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInvitationAnswerMessage : NetworkMessage
  {
    public const uint Id = 5556;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 5556;
      }
    }

    public GuildInvitationAnswerMessage()
    {
    }

    public GuildInvitationAnswerMessage(bool accept)
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
