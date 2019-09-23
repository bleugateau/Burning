using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountToggleRidingRequestMessage : NetworkMessage
  {
    public const uint Id = 5976;

    public override uint MessageId
    {
      get
      {
        return 5976;
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
