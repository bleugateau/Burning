using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
  {
    public new const uint Id = 6218;

    public override uint MessageId
    {
      get
      {
        return 6218;
      }
    }

    public GameFightShowFighterRandomStaticPoseMessage()
    {
    }

    public GameFightShowFighterRandomStaticPoseMessage(GameFightFighterInformations informations)
      : base(informations)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
