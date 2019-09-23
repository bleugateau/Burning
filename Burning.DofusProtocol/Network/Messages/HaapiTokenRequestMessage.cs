using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HaapiTokenRequestMessage : NetworkMessage
  {
    public const uint Id = 6766;

    public override uint MessageId
    {
      get
      {
        return 6766;
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
