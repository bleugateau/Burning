using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectoryAddMessage : NetworkMessage
  {
    public const uint Id = 5651;
    public JobCrafterDirectoryListEntry listEntry;

    public override uint MessageId
    {
      get
      {
        return 5651;
      }
    }

    public JobCrafterDirectoryAddMessage()
    {
    }

    public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
    {
      this.listEntry = listEntry;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.listEntry.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.listEntry = new JobCrafterDirectoryListEntry();
      this.listEntry.Deserialize(reader);
    }
  }
}
