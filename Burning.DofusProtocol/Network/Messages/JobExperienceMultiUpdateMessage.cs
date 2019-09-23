using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobExperienceMultiUpdateMessage : NetworkMessage
  {
    public List<JobExperience> experiencesUpdate = new List<JobExperience>();
    public const uint Id = 5809;

    public override uint MessageId
    {
      get
      {
        return 5809;
      }
    }

    public JobExperienceMultiUpdateMessage()
    {
    }

    public JobExperienceMultiUpdateMessage(List<JobExperience> experiencesUpdate)
    {
      this.experiencesUpdate = experiencesUpdate;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.experiencesUpdate.Count);
      for (int index = 0; index < this.experiencesUpdate.Count; ++index)
        this.experiencesUpdate[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobExperience jobExperience = new JobExperience();
        jobExperience.Deserialize(reader);
        this.experiencesUpdate.Add(jobExperience);
      }
    }
  }
}
