using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
  {
    public new const uint Id = 6728;
    public ArenaRankInfos team;
    public ArenaRankInfos duel;

    public override uint MessageId
    {
      get
      {
        return 6728;
      }
    }

    public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
    {
    }

    public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(
      ArenaRankInfos solo,
      ArenaRankInfos team,
      ArenaRankInfos duel)
      : base(solo)
    {
      this.team = team;
      this.duel = duel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.team.Serialize(writer);
      this.duel.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.team = new ArenaRankInfos();
      this.team.Deserialize(reader);
      this.duel = new ArenaRankInfos();
      this.duel.Deserialize(reader);
    }
  }
}
