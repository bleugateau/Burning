using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class SkillActionDescriptionCraft : SkillActionDescription
  {
    public new const uint Id = 100;
    public uint probability;

    public override uint TypeId
    {
      get
      {
        return 100;
      }
    }

    public SkillActionDescriptionCraft()
    {
    }

    public SkillActionDescriptionCraft(uint skillId, uint probability)
      : base(skillId)
    {
      this.probability = probability;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.probability < 0U)
        throw new Exception("Forbidden value (" + (object) this.probability + ") on element probability.");
      writer.WriteByte((byte) this.probability);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.probability = (uint) reader.ReadByte();
      if (this.probability < 0U)
        throw new Exception("Forbidden value (" + (object) this.probability + ") on element of SkillActionDescriptionCraft.probability.");
    }
  }
}
