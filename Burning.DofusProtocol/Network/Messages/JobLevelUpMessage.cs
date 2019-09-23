using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobLevelUpMessage : NetworkMessage
  {
    public const uint Id = 5656;
    public uint newLevel;
    public JobDescription jobsDescription;

    public override uint MessageId
    {
      get
      {
        return 5656;
      }
    }

    public JobLevelUpMessage()
    {
    }

    public JobLevelUpMessage(uint newLevel, JobDescription jobsDescription)
    {
      this.newLevel = newLevel;
      this.jobsDescription = jobsDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.newLevel < 0U || this.newLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element newLevel.");
      writer.WriteByte((byte) this.newLevel);
      this.jobsDescription.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.newLevel = (uint) reader.ReadByte();
      if (this.newLevel < 0U || this.newLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.newLevel + ") on element of JobLevelUpMessage.newLevel.");
      this.jobsDescription = new JobDescription();
      this.jobsDescription.Deserialize(reader);
    }
  }
}
