using FlatyBot.Common.IO;
using Burning.DofusProtocol.Data.D2P.Elements;
using System;

namespace Burning.DofusProtocol.Data.D2P
{
  public class Cell
  {
    private Layer _layer;

    public int CellId { get; set; }

    public int ElementsCount { get; set; }

    public BasicElement[] Elements { get; set; }

    public Cell(Layer param1)
    {
      this._layer = param1;
    }

    public void FromRaw(BigEndianReader param1, int param2)
    {
      BigEndianReader bigEndianReader = param1;
      int num = param2;
      try
      {
        this.CellId = (int) bigEndianReader.ReadShort();
        this.ElementsCount = (int) bigEndianReader.ReadShort();
        this.Elements = new BasicElement[this.ElementsCount];
        for (int index = 0; index < this.ElementsCount; ++index)
        {
          BasicElement elementFromType = BasicElement.GetElementFromType((int) bigEndianReader.ReadByte(), this);
          elementFromType.FromRaw(bigEndianReader, num);
          this.Elements[index] = elementFromType;
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
