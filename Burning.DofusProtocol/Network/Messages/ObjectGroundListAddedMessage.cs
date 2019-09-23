using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectGroundListAddedMessage : NetworkMessage
  {
    public List<uint> cells = new List<uint>();
    public List<uint> referenceIds = new List<uint>();
    public const uint Id = 5925;

    public override uint MessageId
    {
      get
      {
        return 5925;
      }
    }

    public ObjectGroundListAddedMessage()
    {
    }

    public ObjectGroundListAddedMessage(List<uint> cells, List<uint> referenceIds)
    {
      this.cells = cells;
      this.referenceIds = referenceIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.cells.Count);
      for (int index = 0; index < this.cells.Count; ++index)
      {
        if (this.cells[index] < 0U || this.cells[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.cells[index] + ") on element 1 (starting at 1) of cells.");
        writer.WriteVarShort((short) this.cells[index]);
      }
      writer.WriteShort((short) this.referenceIds.Count);
      for (int index = 0; index < this.referenceIds.Count; ++index)
      {
        if (this.referenceIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.referenceIds[index] + ") on element 2 (starting at 1) of referenceIds.");
        writer.WriteVarShort((short) this.referenceIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of cells.");
        this.cells.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of referenceIds.");
        this.referenceIds.Add(num2);
      }
    }
  }
}
