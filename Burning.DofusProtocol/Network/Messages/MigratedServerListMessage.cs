using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MigratedServerListMessage : NetworkMessage
  {
    public List<uint> migratedServerIds = new List<uint>();
    public const uint Id = 6731;

    public override uint MessageId
    {
      get
      {
        return 6731;
      }
    }

    public MigratedServerListMessage()
    {
    }

    public MigratedServerListMessage(List<uint> migratedServerIds)
    {
      this.migratedServerIds = migratedServerIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.migratedServerIds.Count);
      for (int index = 0; index < this.migratedServerIds.Count; ++index)
      {
        if (this.migratedServerIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.migratedServerIds[index] + ") on element 1 (starting at 1) of migratedServerIds.");
        writer.WriteVarShort((short) this.migratedServerIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of migratedServerIds.");
        this.migratedServerIds.Add(num2);
      }
    }
  }
}
