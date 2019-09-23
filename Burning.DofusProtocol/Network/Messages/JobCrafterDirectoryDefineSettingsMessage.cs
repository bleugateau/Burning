using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
  {
    public const uint Id = 5649;
    public JobCrafterDirectorySettings settings;

    public override uint MessageId
    {
      get
      {
        return 5649;
      }
    }

    public JobCrafterDirectoryDefineSettingsMessage()
    {
    }

    public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
    {
      this.settings = settings;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.settings.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.settings = new JobCrafterDirectorySettings();
      this.settings.Deserialize(reader);
    }
  }
}
