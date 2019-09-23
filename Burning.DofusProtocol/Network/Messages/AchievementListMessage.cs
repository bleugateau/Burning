using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AchievementListMessage : NetworkMessage
  {
    public List<AchievementAchieved> finishedAchievements = new List<AchievementAchieved>();
    public const uint Id = 6205;

    public override uint MessageId
    {
      get
      {
        return 6205;
      }
    }

    public AchievementListMessage()
    {
    }

    public AchievementListMessage(List<AchievementAchieved> finishedAchievements)
    {
      this.finishedAchievements = finishedAchievements;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.finishedAchievements.Count);
      for (int index = 0; index < this.finishedAchievements.Count; ++index)
      {
        writer.WriteShort((short) this.finishedAchievements[index].TypeId);
        this.finishedAchievements[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AchievementAchieved instance = ProtocolTypeManager.GetInstance<AchievementAchieved>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.finishedAchievements.Add(instance);
      }
    }
  }
}
