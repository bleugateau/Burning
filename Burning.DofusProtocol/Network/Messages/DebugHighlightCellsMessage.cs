using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DebugHighlightCellsMessage : NetworkMessage
  {
    public List<uint> cells = new List<uint>();
    public const uint Id = 2001;
    public double color;

    public override uint MessageId
    {
      get
      {
        return 2001;
      }
    }

    public DebugHighlightCellsMessage()
    {
    }

    public DebugHighlightCellsMessage(double color, List<uint> cells)
    {
      this.color = color;
      this.cells = cells;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.color < -9.00719925474099E+15 || this.color > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.color + ") on element color.");
      writer.WriteDouble(this.color);
      writer.WriteShort((short) this.cells.Count);
      for (int index = 0; index < this.cells.Count; ++index)
      {
        if (this.cells[index] < 0U || this.cells[index] > 559U)
          throw new Exception("Forbidden value (" + (object) this.cells[index] + ") on element 2 (starting at 1) of cells.");
        writer.WriteVarShort((short) this.cells[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.color = reader.ReadDouble();
      if (this.color < -9.00719925474099E+15 || this.color > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.color + ") on element of DebugHighlightCellsMessage.color.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U || num2 > 559U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of cells.");
        this.cells.Add(num2);
      }
    }
  }
}
