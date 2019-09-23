using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class SkillActionDescription
  {
    public const uint Id = 102;
    public uint skillId;

    public virtual uint TypeId
    {
      get
      {
        return 102;
      }
    }

    public SkillActionDescription()
    {
    }

    public SkillActionDescription(uint skillId)
    {
      this.skillId = skillId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element skillId.");
      writer.WriteVarShort((short) this.skillId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.skillId = (uint) reader.ReadVarUhShort();
      if (this.skillId < 0U)
        throw new Exception("Forbidden value (" + (object) this.skillId + ") on element of SkillActionDescription.skillId.");
    }
  }
}
