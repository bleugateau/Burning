using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnStartPlayingMessage : NetworkMessage
  {
    public const uint Id = 6465;

    public override uint MessageId
    {
      get
      {
        return 6465;
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
