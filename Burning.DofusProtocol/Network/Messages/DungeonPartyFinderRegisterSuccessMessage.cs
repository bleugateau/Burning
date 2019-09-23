using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DungeonPartyFinderRegisterSuccessMessage : NetworkMessage
  {
    public List<uint> dungeonIds = new List<uint>();
    public const uint Id = 6241;

    public override uint MessageId
    {
      get
      {
        return 6241;
      }
    }

    public DungeonPartyFinderRegisterSuccessMessage()
    {
    }

    public DungeonPartyFinderRegisterSuccessMessage(List<uint> dungeonIds)
    {
      this.dungeonIds = dungeonIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.dungeonIds.Count);
      for (int index = 0; index < this.dungeonIds.Count; ++index)
      {
        if (this.dungeonIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.dungeonIds[index] + ") on element 1 (starting at 1) of dungeonIds.");
        writer.WriteVarShort((short) this.dungeonIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of dungeonIds.");
        this.dungeonIds.Add(num2);
      }
    }
  }
}
