using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountReleaseRequestMessage : NetworkMessage
  {
    public const uint Id = 5980;

    public override uint MessageId
    {
      get
      {
        return 5980;
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
