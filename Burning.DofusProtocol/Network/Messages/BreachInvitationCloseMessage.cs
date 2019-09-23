using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachInvitationCloseMessage : NetworkMessage
  {
    public const uint Id = 6790;
    public CharacterMinimalInformations host;

    public override uint MessageId
    {
      get
      {
        return 6790;
      }
    }

    public BreachInvitationCloseMessage()
    {
    }

    public BreachInvitationCloseMessage(CharacterMinimalInformations host)
    {
      this.host = host;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.host.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.host = new CharacterMinimalInformations();
      this.host.Deserialize(reader);
    }
  }
}
