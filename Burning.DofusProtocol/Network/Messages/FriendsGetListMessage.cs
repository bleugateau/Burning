using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendsGetListMessage : NetworkMessage
  {
    public const uint Id = 4001;

    public override uint MessageId
    {
      get
      {
        return 4001;
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
