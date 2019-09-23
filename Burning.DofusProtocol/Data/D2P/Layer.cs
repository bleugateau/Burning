using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Data.D2P
{
  public class Layer
  {
    public const uint LayerGround = 0;
    public const uint LayerAdditionalGround = 1;
    public const uint LayerDecor = 2;
    public const uint LayerAdditionalDecor = 3;
    public int RefCell;
    private Map _map;

    public int LayerId { get; set; }

    public int CellsCount { get; set; }

    public Cell[] Cells { get; set; }

    public Layer(Map param1)
    {
      this._map = param1;
    }

    public void FromRaw(BigEndianReader param1, int param2)
    {
      BigEndianReader bigEndianReader = param1;
      int num = param2;
      try
      {
        this.LayerId = num >= 9 ? (int) bigEndianReader.ReadByte() : bigEndianReader.ReadInt();
        this.CellsCount = (int) bigEndianReader.ReadShort();
        this.Cells = new Cell[this.CellsCount];
        for (int index = 0; index < this.CellsCount; ++index)
        {
          Cell cell = new Cell(this);
          cell.FromRaw(bigEndianReader, num);
          this.Cells[index] = cell;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        throw;
      }
    }
  }
}
