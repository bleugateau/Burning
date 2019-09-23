using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobDescription
  {
    public List<SkillActionDescription> skills = new List<SkillActionDescription>();
    public const uint Id = 101;
    public uint jobId;

    public virtual uint TypeId
    {
      get
      {
        return 101;
      }
    }

    public JobDescription()
    {
    }

    public JobDescription(uint jobId, List<SkillActionDescription> skills)
    {
      this.jobId = jobId;
      this.skills = skills;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      writer.WriteShort((short) this.skills.Count);
      for (int index = 0; index < this.skills.Count; ++index)
      {
        writer.WriteShort((short) this.skills[index].TypeId);
        this.skills[index].Serialize(writer);
      }
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobDescription.jobId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        SkillActionDescription instance = ProtocolTypeManager.GetInstance<SkillActionDescription>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.skills.Add(instance);
      }
    }
  }
}
