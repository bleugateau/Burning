using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobCrafterDirectorySettings
  {
    public const uint Id = 97;
    public uint jobId;
    public uint minLevel;
    public bool free;

    public virtual uint TypeId
    {
      get
      {
        return 97;
      }
    }

    public JobCrafterDirectorySettings()
    {
    }

    public JobCrafterDirectorySettings(uint jobId, uint minLevel, bool free)
    {
      this.jobId = jobId;
      this.minLevel = minLevel;
      this.free = free;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      if (this.minLevel < 0U || this.minLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.minLevel + ") on element minLevel.");
      writer.WriteByte((byte) this.minLevel);
      writer.WriteBoolean(this.free);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobCrafterDirectorySettings.jobId.");
      this.minLevel = (uint) reader.ReadByte();
      if (this.minLevel < 0U || this.minLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.minLevel + ") on element of JobCrafterDirectorySettings.minLevel.");
      this.free = reader.ReadBoolean();
    }
  }
}
