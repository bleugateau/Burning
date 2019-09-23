using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameMapMovementConfirmMessage : NetworkMessage
  {
    public const uint Id = 952;

    public override uint MessageId
    {
      get
      {
        return 952;
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
