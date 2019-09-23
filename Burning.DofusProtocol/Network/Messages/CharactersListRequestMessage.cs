using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CharactersListRequestMessage : NetworkMessage
  {
    public const uint Id = 150;

    public override uint MessageId
    {
      get
      {
        return 150;
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
