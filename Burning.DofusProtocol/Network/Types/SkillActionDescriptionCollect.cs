using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
  {
    public new const uint Id = 99;
    public uint min;
    public uint max;

    public override uint TypeId
    {
      get
      {
        return 99;
      }
    }

    public SkillActionDescriptionCollect()
    {
    }

    public SkillActionDescriptionCollect(uint skillId, uint time, uint min, uint max)
      : base(skillId, time)
    {
      this.min = min;
      this.max = max;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.min < 0U)
        throw new Exception("Forbidden value (" + (object) this.min + ") on element min.");
      writer.WriteVarShort((short) this.min);
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element max.");
      writer.WriteVarShort((short) this.max);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.min = (uint) reader.ReadVarUhShort();
      if (this.min < 0U)
        throw new Exception("Forbidden value (" + (object) this.min + ") on element of SkillActionDescriptionCollect.min.");
      this.max = (uint) reader.ReadVarUhShort();
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element of SkillActionDescriptionCollect.max.");
    }
  }
}
