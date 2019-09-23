using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobCrafterDirectoryEntryJobInfo
  {
    public const uint Id = 195;
    public uint jobId;
    public uint jobLevel;
    public bool free;
    public uint minLevel;

    public virtual uint TypeId
    {
      get
      {
        return 195;
      }
    }

    public JobCrafterDirectoryEntryJobInfo()
    {
    }

    public JobCrafterDirectoryEntryJobInfo(uint jobId, uint jobLevel, bool free, uint minLevel)
    {
      this.jobId = jobId;
      this.jobLevel = jobLevel;
      this.free = free;
      this.minLevel = minLevel;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      if (this.jobLevel < 1U || this.jobLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.jobLevel + ") on element jobLevel.");
      writer.WriteByte((byte) this.jobLevel);
      writer.WriteBoolean(this.free);
      if (this.minLevel < 0U || this.minLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.minLevel + ") on element minLevel.");
      writer.WriteByte((byte) this.minLevel);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobCrafterDirectoryEntryJobInfo.jobId.");
      this.jobLevel = (uint) reader.ReadByte();
      if (this.jobLevel < 1U || this.jobLevel > 200U)
        throw new Exception("Forbidden value (" + (object) this.jobLevel + ") on element of JobCrafterDirectoryEntryJobInfo.jobLevel.");
      this.free = reader.ReadBoolean();
      this.minLevel = (uint) reader.ReadByte();
      if (this.minLevel < 0U || this.minLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.minLevel + ") on element of JobCrafterDirectoryEntryJobInfo.minLevel.");
    }
  }
}
