using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ConnectionRequestMessage : NetworkMessage
  {
    public const uint Id = 7985;

    public override uint MessageId
    {
      get
      {
        return 7985;
      }
    }

    public short TheBig { get; set; }

    public override void Deserialize(IDataReader reader)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
    }
  }
}
