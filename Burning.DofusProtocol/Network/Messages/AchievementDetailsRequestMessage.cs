using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementDetailsRequestMessage : NetworkMessage
  {
    public const uint Id = 6380;
    public uint achievementId;

    public override uint MessageId
    {
      get
      {
        return 6380;
      }
    }

    public AchievementDetailsRequestMessage()
    {
    }

    public AchievementDetailsRequestMessage(uint achievementId)
    {
      this.achievementId = achievementId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.achievementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.achievementId + ") on element achievementId.");
      writer.WriteVarShort((short) this.achievementId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.achievementId = (uint) reader.ReadVarUhShort();
      if (this.achievementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.achievementId + ") on element of AchievementDetailsRequestMessage.achievementId.");
    }
  }
}
