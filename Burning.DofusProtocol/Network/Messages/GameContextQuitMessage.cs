using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextQuitMessage : NetworkMessage
  {
    public const uint Id = 255;

    public override uint MessageId
    {
      get
      {
        return (uint) byte.MaxValue;
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
