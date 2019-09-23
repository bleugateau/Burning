using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NotificationResetMessage : NetworkMessage
  {
    public const uint Id = 6089;

    public override uint MessageId
    {
      get
      {
        return 6089;
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
