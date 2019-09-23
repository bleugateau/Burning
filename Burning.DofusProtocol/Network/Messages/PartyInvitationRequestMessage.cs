using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationRequestMessage : NetworkMessage
  {
    public const uint Id = 5585;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 5585;
      }
    }

    public PartyInvitationRequestMessage()
    {
    }

    public PartyInvitationRequestMessage(string name)
    {
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
    }
  }
}
