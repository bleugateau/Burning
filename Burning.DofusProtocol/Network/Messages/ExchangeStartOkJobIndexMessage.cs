using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkJobIndexMessage : NetworkMessage
  {
    public List<uint> jobs = new List<uint>();
    public const uint Id = 5819;

    public override uint MessageId
    {
      get
      {
        return 5819;
      }
    }

    public ExchangeStartOkJobIndexMessage()
    {
    }

    public ExchangeStartOkJobIndexMessage(List<uint> jobs)
    {
      this.jobs = jobs;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.jobs.Count);
      for (int index = 0; index < this.jobs.Count; ++index)
      {
        if (this.jobs[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.jobs[index] + ") on element 1 (starting at 1) of jobs.");
        writer.WriteVarInt((int) this.jobs[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of jobs.");
        this.jobs.Add(num2);
      }
    }
  }
}
