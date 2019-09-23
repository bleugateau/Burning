using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachInvitationResponseMessage : NetworkMessage
  {
    public const uint Id = 6792;
    public CharacterMinimalInformations guest;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6792;
      }
    }

    public BreachInvitationResponseMessage()
    {
    }

    public BreachInvitationResponseMessage(CharacterMinimalInformations guest, bool accept)
    {
      this.guest = guest;
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.guest.Serialize(writer);
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guest = new CharacterMinimalInformations();
      this.guest.Deserialize(reader);
      this.accept = reader.ReadBoolean();
    }
  }
}
