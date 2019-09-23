using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class SkillActionDescriptionTimed : SkillActionDescription
  {
    public new const uint Id = 103;
    public uint time;

    public override uint TypeId
    {
      get
      {
        return 103;
      }
    }

    public SkillActionDescriptionTimed()
    {
    }

    public SkillActionDescriptionTimed(uint skillId, uint time)
      : base(skillId)
    {
      this.time = time;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.time < 0U || this.time > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.time + ") on element time.");
      writer.WriteByte((byte) this.time);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.time = (uint) reader.ReadByte();
      if (this.time < 0U || this.time > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.time + ") on element of SkillActionDescriptionTimed.time.");
    }
  }
}
