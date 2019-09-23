using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementRewardErrorMessage : NetworkMessage
  {
    public const uint Id = 6375;
    public int achievementId;

    public override uint MessageId
    {
      get
      {
        return 6375;
      }
    }

    public AchievementRewardErrorMessage()
    {
    }

    public AchievementRewardErrorMessage(int achievementId)
    {
      this.achievementId = achievementId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.achievementId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.achievementId = (int) reader.ReadShort();
    }
  }
}
