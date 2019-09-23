using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobExperienceUpdateMessage : NetworkMessage
  {
    public const uint Id = 5654;
    public JobExperience experiencesUpdate;

    public override uint MessageId
    {
      get
      {
        return 5654;
      }
    }

    public JobExperienceUpdateMessage()
    {
    }

    public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
    {
      this.experiencesUpdate = experiencesUpdate;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.experiencesUpdate.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.experiencesUpdate = new JobExperience();
      this.experiencesUpdate.Deserialize(reader);
    }
  }
}
