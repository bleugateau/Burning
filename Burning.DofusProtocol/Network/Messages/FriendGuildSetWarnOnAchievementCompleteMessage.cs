using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendGuildSetWarnOnAchievementCompleteMessage : NetworkMessage
  {
    public const uint Id = 6382;
    public bool enable;

    public override uint MessageId
    {
      get
      {
        return 6382;
      }
    }

    public FriendGuildSetWarnOnAchievementCompleteMessage()
    {
    }

    public FriendGuildSetWarnOnAchievementCompleteMessage(bool enable)
    {
      this.enable = enable;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.enable);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.enable = reader.ReadBoolean();
    }
  }
}
