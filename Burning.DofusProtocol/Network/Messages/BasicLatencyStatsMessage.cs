using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BasicLatencyStatsMessage : NetworkMessage
  {
    public const uint Id = 5663;
    public uint latency;
    public uint sampleCount;
    public uint max;

    public override uint MessageId
    {
      get
      {
        return 5663;
      }
    }

    public BasicLatencyStatsMessage()
    {
    }

    public BasicLatencyStatsMessage(uint latency, uint sampleCount, uint max)
    {
      this.latency = latency;
      this.sampleCount = sampleCount;
      this.max = max;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.latency < 0U || this.latency > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.latency + ") on element latency.");
      writer.WriteShort((short) this.latency);
      if (this.sampleCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.sampleCount + ") on element sampleCount.");
      writer.WriteVarShort((short) this.sampleCount);
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element max.");
      writer.WriteVarShort((short) this.max);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.latency = (uint) reader.ReadUShort();
      if (this.latency < 0U || this.latency > (uint) ushort.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.latency + ") on element of BasicLatencyStatsMessage.latency.");
      this.sampleCount = (uint) reader.ReadVarUhShort();
      if (this.sampleCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.sampleCount + ") on element of BasicLatencyStatsMessage.sampleCount.");
      this.max = (uint) reader.ReadVarUhShort();
      if (this.max < 0U)
        throw new Exception("Forbidden value (" + (object) this.max + ") on element of BasicLatencyStatsMessage.max.");
    }
  }
}
