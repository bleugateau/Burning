using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AchievementAchievedRewardable : AchievementAchieved
  {
    public new const uint Id = 515;
    public uint finishedlevel;

    public override uint TypeId
    {
      get
      {
        return 515;
      }
    }

    public AchievementAchievedRewardable()
    {
    }

    public AchievementAchievedRewardable(uint id, double achievedBy, uint finishedlevel)
      : base(id, achievedBy)
    {
      this.finishedlevel = finishedlevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.finishedlevel < 0U || this.finishedlevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.finishedlevel + ") on element finishedlevel.");
      writer.WriteVarShort((short) this.finishedlevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.finishedlevel = (uint) reader.ReadVarUhShort();
      if (this.finishedlevel < 0U || this.finishedlevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.finishedlevel + ") on element of AchievementAchievedRewardable.finishedlevel.");
    }
  }
}
