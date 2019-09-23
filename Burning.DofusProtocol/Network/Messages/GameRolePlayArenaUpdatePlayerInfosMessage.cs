using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
  {
    public const uint Id = 6301;
    public ArenaRankInfos solo;

    public override uint MessageId
    {
      get
      {
        return 6301;
      }
    }

    public GameRolePlayArenaUpdatePlayerInfosMessage()
    {
    }

    public GameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos solo)
    {
      this.solo = solo;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.solo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.solo = new ArenaRankInfos();
      this.solo.Deserialize(reader);
    }
  }
}
