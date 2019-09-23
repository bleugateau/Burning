using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharacterCanBeCreatedRequestMessage : NetworkMessage
  {
    public const uint Id = 6732;

    public override uint MessageId
    {
      get
      {
        return 6732;
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
