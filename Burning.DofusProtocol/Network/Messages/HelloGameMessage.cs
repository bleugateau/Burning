using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HelloGameMessage : NetworkMessage
  {
    public const uint Id = 101;

    public override uint MessageId
    {
      get
      {
        return 101;
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
