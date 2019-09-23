using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AuthenticationTicketAcceptedMessage : NetworkMessage
  {
    public const uint Id = 111;

    public override uint MessageId
    {
      get
      {
        return 111;
      }
    }

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
  }
}
