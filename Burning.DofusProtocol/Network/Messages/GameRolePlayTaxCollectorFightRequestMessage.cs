using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayTaxCollectorFightRequestMessage : NetworkMessage
  {
    public const uint Id = 5954;

    public override uint MessageId
    {
      get
      {
        return 5954;
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
