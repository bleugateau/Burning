using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceInvitationAnswerMessage : NetworkMessage
  {
    public const uint Id = 6401;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6401;
      }
    }

    public AllianceInvitationAnswerMessage()
    {
    }

    public AllianceInvitationAnswerMessage(bool accept)
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
