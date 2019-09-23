using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AcquaintanceServerListMessage : NetworkMessage
  {
    public List<uint> servers = new List<uint>();
    public const uint Id = 6142;

    public override uint MessageId
    {
      get
      {
        return 6142;
      }
    }

    public AcquaintanceServerListMessage()
    {
    }

    public AcquaintanceServerListMessage(List<uint> servers)
    {
      this.servers = servers;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.servers.Count);
      for (int index = 0; index < this.servers.Count; ++index)
      {
        if (this.servers[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.servers[index] + ") on element 1 (starting at 1) of servers.");
        writer.WriteVarShort((short) this.servers[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of servers.");
        this.servers.Add(num2);
      }
    }
  }
}
