using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayGameOverMessage : NetworkMessage
  {
    public const uint Id = 746;

    public override uint MessageId
    {
      get
      {
        return 746;
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
