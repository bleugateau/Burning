using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IgnoredGetListMessage : NetworkMessage
  {
    public const uint Id = 5676;

    public override uint MessageId
    {
      get
      {
        return 5676;
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
