using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectTransfertAllToInvMessage : NetworkMessage
  {
    public const uint Id = 6032;

    public override uint MessageId
    {
      get
      {
        return 6032;
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
