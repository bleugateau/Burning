using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobDescriptionMessage : NetworkMessage
  {
    public List<JobDescription> jobsDescription = new List<JobDescription>();
    public const uint Id = 5655;

    public override uint MessageId
    {
      get
      {
        return 5655;
      }
    }

    public JobDescriptionMessage()
    {
    }

    public JobDescriptionMessage(List<JobDescription> jobsDescription)
    {
      this.jobsDescription = jobsDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.jobsDescription.Count);
      for (int index = 0; index < this.jobsDescription.Count; ++index)
        this.jobsDescription[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobDescription jobDescription = new JobDescription();
        jobDescription.Deserialize(reader);
        this.jobsDescription.Add(jobDescription);
      }
    }
  }
}
