using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterSelectedForceReadyMessage : NetworkMessage
  {
    public const uint Id = 6072;

    public override uint MessageId
    {
      get
      {
        return 6072;
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
