using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextDestroyMessage : NetworkMessage
  {
    public const uint Id = 201;

    public override uint MessageId
    {
      get
      {
        return 201;
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
