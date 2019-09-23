using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementDetailedListMessage : NetworkMessage
  {
    public List<Achievement> startedAchievements = new List<Achievement>();
    public List<Achievement> finishedAchievements = new List<Achievement>();
    public const uint Id = 6358;

    public override uint MessageId
    {
      get
      {
        return 6358;
      }
    }

    public AchievementDetailedListMessage()
    {
    }

    public AchievementDetailedListMessage(
      List<Achievement> startedAchievements,
      List<Achievement> finishedAchievements)
    {
      this.startedAchievements = startedAchievements;
      this.finishedAchievements = finishedAchievements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.startedAchievements.Count);
      for (int index = 0; index < this.startedAchievements.Count; ++index)
        this.startedAchievements[index].Serialize(writer);
      writer.WriteShort((short) this.finishedAchievements.Count);
      for (int index = 0; index < this.finishedAchievements.Count; ++index)
        this.finishedAchievements[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        Achievement achievement = new Achievement();
        achievement.Deserialize(reader);
        this.startedAchievements.Add(achievement);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        Achievement achievement = new Achievement();
        achievement.Deserialize(reader);
        this.finishedAchievements.Add(achievement);
      }
    }
  }
}
