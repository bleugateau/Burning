using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementFinishedMessage : NetworkMessage
  {
    public const uint Id = 6208;
    public AchievementAchievedRewardable achievement;

    public override uint MessageId
    {
      get
      {
        return 6208;
      }
    }

    public AchievementFinishedMessage()
    {
    }

    public AchievementFinishedMessage(AchievementAchievedRewardable achievement)
    {
      this.achievement = achievement;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.achievement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.achievement = new AchievementAchievedRewardable();
      this.achievement.Deserialize(reader);
    }
  }
}
