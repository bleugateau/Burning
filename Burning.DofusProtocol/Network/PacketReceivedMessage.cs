using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network
{
  public class PacketReceivedMessage : NetworkMessage
  {
    public const uint Id = 9987;

    public override uint MessageId
    {
      get
      {
        return 9987;
      }
    }

    public override void Deserialize(IDataReader reader)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
    }
  }
}
