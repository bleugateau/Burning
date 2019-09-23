using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class Achievement
  {
    public List<AchievementObjective> finishedObjective = new List<AchievementObjective>();
    public List<AchievementStartedObjective> startedObjectives = new List<AchievementStartedObjective>();
    public const uint Id = 363;
    public uint id;

    public virtual uint TypeId
    {
      get
      {
        return 363;
      }
    }

    public Achievement()
    {
    }

    public Achievement(
      uint id,
      List<AchievementObjective> finishedObjective,
      List<AchievementStartedObjective> startedObjectives)
    {
      this.id = id;
      this.finishedObjective = finishedObjective;
      this.startedObjectives = startedObjectives;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      writer.WriteShort((short) this.finishedObjective.Count);
      for (int index = 0; index < this.finishedObjective.Count; ++index)
        this.finishedObjective[index].Serialize(writer);
      writer.WriteShort((short) this.startedObjectives.Count);
      for (int index = 0; index < this.startedObjectives.Count; ++index)
        this.startedObjectives[index].Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of Achievement.id.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        AchievementObjective achievementObjective = new AchievementObjective();
        achievementObjective.Deserialize(reader);
        this.finishedObjective.Add(achievementObjective);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        AchievementStartedObjective startedObjective = new AchievementStartedObjective();
        startedObjective.Deserialize(reader);
        this.startedObjectives.Add(startedObjective);
      }
    }
  }
}
