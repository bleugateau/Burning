using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobCrafterDirectoryEntryMessage : NetworkMessage
  {
    public List<JobCrafterDirectoryEntryJobInfo> jobInfoList = new List<JobCrafterDirectoryEntryJobInfo>();
    public const uint Id = 6044;
    public JobCrafterDirectoryEntryPlayerInfo playerInfo;
    public EntityLook playerLook;

    public override uint MessageId
    {
      get
      {
        return 6044;
      }
    }

    public JobCrafterDirectoryEntryMessage()
    {
    }

    public JobCrafterDirectoryEntryMessage(
      JobCrafterDirectoryEntryPlayerInfo playerInfo,
      List<JobCrafterDirectoryEntryJobInfo> jobInfoList,
      EntityLook playerLook)
    {
      this.playerInfo = playerInfo;
      this.jobInfoList = jobInfoList;
      this.playerLook = playerLook;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.playerInfo.Serialize(writer);
      writer.WriteShort((short) this.jobInfoList.Count);
      for (int index = 0; index < this.jobInfoList.Count; ++index)
        this.jobInfoList[index].Serialize(writer);
      this.playerLook.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
      this.playerInfo.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        JobCrafterDirectoryEntryJobInfo directoryEntryJobInfo = new JobCrafterDirectoryEntryJobInfo();
        directoryEntryJobInfo.Deserialize(reader);
        this.jobInfoList.Add(directoryEntryJobInfo);
      }
      this.playerLook = new EntityLook();
      this.playerLook.Deserialize(reader);
    }
  }
}
