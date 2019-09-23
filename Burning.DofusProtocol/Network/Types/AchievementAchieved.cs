using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AchievementAchieved
  {
    public const uint Id = 514;
    public uint id;
    public double achievedBy;

    public virtual uint TypeId
    {
      get
      {
        return 514;
      }
    }

    public AchievementAchieved()
    {
    }

    public AchievementAchieved(uint id, double achievedBy)
    {
      this.id = id;
      this.achievedBy = achievedBy;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      if (this.achievedBy < 0.0 || this.achievedBy > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.achievedBy + ") on element achievedBy.");
      writer.WriteVarLong((long) this.achievedBy);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of AchievementAchieved.id.");
      this.achievedBy = (double) reader.ReadVarUhLong();
      if (this.achievedBy < 0.0 || this.achievedBy > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.achievedBy + ") on element of AchievementAchieved.achievedBy.");
    }
  }
}
