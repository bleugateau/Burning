using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InviteInHavenBagClosedMessage : NetworkMessage
  {
    public const uint Id = 6645;
    public CharacterMinimalInformations hostInformations;

    public override uint MessageId
    {
      get
      {
        return 6645;
      }
    }

    public InviteInHavenBagClosedMessage()
    {
    }

    public InviteInHavenBagClosedMessage(CharacterMinimalInformations hostInformations)
    {
      this.hostInformations = hostInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.hostInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.hostInformations = new CharacterMinimalInformations();
      this.hostInformations.Deserialize(reader);
    }
  }
}
