using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeReplayStopMessage : NetworkMessage
  {
    public const uint Id = 6001;

    public override uint MessageId
    {
      get
      {
        return 6001;
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
