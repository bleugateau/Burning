using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayShowChallengeMessage : NetworkMessage
  {
    public const uint Id = 301;
    public FightCommonInformations commonsInfos;

    public override uint MessageId
    {
      get
      {
        return 301;
      }
    }

    public GameRolePlayShowChallengeMessage()
    {
    }

    public GameRolePlayShowChallengeMessage(FightCommonInformations commonsInfos)
    {
      this.commonsInfos = commonsInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.commonsInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.commonsInfos = new FightCommonInformations();
      this.commonsInfos.Deserialize(reader);
    }
  }
}
