using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobBookSubscription
  {
    public const uint Id = 500;
    public uint jobId;
    public bool subscribed;

    public virtual uint TypeId
    {
      get
      {
        return 500;
      }
    }

    public JobBookSubscription()
    {
    }

    public JobBookSubscription(uint jobId, bool subscribed)
    {
      this.jobId = jobId;
      this.subscribed = subscribed;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      writer.WriteBoolean(this.subscribed);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobBookSubscription.jobId.");
      this.subscribed = reader.ReadBoolean();
    }
  }
}
