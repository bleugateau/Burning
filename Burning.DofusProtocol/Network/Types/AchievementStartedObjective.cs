using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AchievementStartedObjective : AchievementObjective
  {
    public new const uint Id = 402;
    public uint value;

    public override uint TypeId
    {
      get
      {
        return 402;
      }
    }

    public AchievementStartedObjective()
    {
    }

    public AchievementStartedObjective(uint id, uint maxValue, uint value)
      : base(id, maxValue)
    {
      this.value = value;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.value < 0U)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element value.");
      writer.WriteVarShort((short) this.value);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.value = (uint) reader.ReadVarUhShort();
      if (this.value < 0U)
        throw new Exception("Forbidden value (" + (object) this.value + ") on element of AchievementStartedObjective.value.");
    }
  }
}
