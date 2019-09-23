using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AcquaintancesGetListMessage : NetworkMessage
  {
    public const uint Id = 6819;

    public override uint MessageId
    {
      get
      {
        return 6819;
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
