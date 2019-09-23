using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectorySettingsMessage : NetworkMessage
  {
    public List<JobCrafterDirectorySettings> craftersSettings = new List<JobCrafterDirectorySettings>();
    public const uint Id = 5652;

    public override uint MessageId
    {
      get
      {
        return 5652;
      }
    }

    public JobCrafterDirectorySettingsMessage()
    {
    }

    public JobCrafterDirectorySettingsMessage(List<JobCrafterDirectorySettings> craftersSettings)
    {
      this.craftersSettings = craftersSettings;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.craftersSettings.Count);
      for (int index = 0; index < this.craftersSettings.Count; ++index)
        this.craftersSettings[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobCrafterDirectorySettings directorySettings = new JobCrafterDirectorySettings();
        directorySettings.Deserialize(reader);
        this.craftersSettings.Add(directorySettings);
      }
    }
  }
}
