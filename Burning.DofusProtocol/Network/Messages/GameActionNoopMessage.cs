using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionNoopMessage : NetworkMessage
  {
    public const uint Id = 1002;

    public override uint MessageId
    {
      get
      {
        return 1002;
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
