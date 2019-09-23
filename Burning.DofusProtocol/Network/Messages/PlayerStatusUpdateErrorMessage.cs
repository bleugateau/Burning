using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PlayerStatusUpdateErrorMessage : NetworkMessage
  {
    public const uint Id = 6385;

    public override uint MessageId
    {
      get
      {
        return 6385;
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
