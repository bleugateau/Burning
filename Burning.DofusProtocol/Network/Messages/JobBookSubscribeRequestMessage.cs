using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class JobBookSubscribeRequestMessage : NetworkMessage
  {
    public List<uint> jobIds = new List<uint>();
    public const uint Id = 6592;

    public override uint MessageId
    {
      get
      {
        return 6592;
      }
    }

    public JobBookSubscribeRequestMessage()
    {
    }

    public JobBookSubscribeRequestMessage(List<uint> jobIds)
    {
      this.jobIds = jobIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.jobIds.Count);
      for (int index = 0; index < this.jobIds.Count; ++index)
      {
        if (this.jobIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.jobIds[index] + ") on element 1 (starting at 1) of jobIds.");
        writer.WriteByte((byte) this.jobIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of jobIds.");
        this.jobIds.Add(num2);
      }
    }
  }
}
