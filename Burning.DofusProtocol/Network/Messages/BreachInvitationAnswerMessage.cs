using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachInvitationAnswerMessage : NetworkMessage
  {
    public const uint Id = 6795;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6795;
      }
    }

    public BreachInvitationAnswerMessage()
    {
    }

    public BreachInvitationAnswerMessage(bool accept)
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
