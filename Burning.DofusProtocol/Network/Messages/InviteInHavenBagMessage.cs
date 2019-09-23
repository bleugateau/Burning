using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InviteInHavenBagMessage : NetworkMessage
  {
    public const uint Id = 6642;
    public CharacterMinimalInformations guestInformations;
    public bool accept;

    public override uint MessageId
    {
      get
      {
        return 6642;
      }
    }

    public InviteInHavenBagMessage()
    {
    }

    public InviteInHavenBagMessage(CharacterMinimalInformations guestInformations, bool accept)
    {
      this.guestInformations = guestInformations;
      this.accept = accept;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.guestInformations.Serialize(writer);
      writer.WriteBoolean(this.accept);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.guestInformations = new CharacterMinimalInformations();
      this.guestInformations.Deserialize(reader);
      this.accept = reader.ReadBoolean();
    }
  }
}
