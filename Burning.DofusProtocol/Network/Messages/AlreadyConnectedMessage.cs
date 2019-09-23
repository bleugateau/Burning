using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AlreadyConnectedMessage : NetworkMessage
  {
    public const uint Id = 109;

    public override uint MessageId
    {
      get
      {
        return 109;
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
