using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectoryListMessage : NetworkMessage
  {
    public List<JobCrafterDirectoryListEntry> listEntries = new List<JobCrafterDirectoryListEntry>();
    public const uint Id = 6046;

    public override uint MessageId
    {
      get
      {
        return 6046;
      }
    }

    public JobCrafterDirectoryListMessage()
    {
    }

    public JobCrafterDirectoryListMessage(List<JobCrafterDirectoryListEntry> listEntries)
    {
      this.listEntries = listEntries;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.listEntries.Count);
      for (int index = 0; index < this.listEntries.Count; ++index)
        this.listEntries[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobCrafterDirectoryListEntry directoryListEntry = new JobCrafterDirectoryListEntry();
        directoryListEntry.Deserialize(reader);
        this.listEntries.Add(directoryListEntry);
      }
    }
  }
}
