using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementDetailsMessage : NetworkMessage
  {
    public const uint Id = 6378;
    public Achievement achievement;

    public override uint MessageId
    {
      get
      {
        return 6378;
      }
    }

    public AchievementDetailsMessage()
    {
    }

    public AchievementDetailsMessage(Achievement achievement)
    {
      this.achievement = achievement;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.achievement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.achievement = new Achievement();
      this.achievement.Deserialize(reader);
    }
  }
}
