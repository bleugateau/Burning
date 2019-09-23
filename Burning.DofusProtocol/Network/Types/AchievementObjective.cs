using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AchievementObjective
  {
    public const uint Id = 404;
    public uint id;
    public uint maxValue;

    public virtual uint TypeId
    {
      get
      {
        return 404;
      }
    }

    public AchievementObjective()
    {
    }

    public AchievementObjective(uint id, uint maxValue)
    {
      this.id = id;
      this.maxValue = maxValue;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarInt((int) this.id);
      if (this.maxValue < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxValue + ") on element maxValue.");
      writer.WriteVarShort((short) this.maxValue);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadVarUhInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of AchievementObjective.id.");
      this.maxValue = (uint) reader.ReadVarUhShort();
      if (this.maxValue < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxValue + ") on element of AchievementObjective.maxValue.");
    }
  }
}
