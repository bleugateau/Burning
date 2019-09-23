using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Data.D2P.Elements
{
  public abstract class BasicElement
  {
    protected BasicElement(Cell cell)
    {
      this.Cell = cell;
    }

    public static BasicElement GetElementFromType(int elementType, Cell cell)
    {
      if (elementType == 2)
        return (BasicElement) new GraphicalElement(cell);
      if (elementType == 33)
        return (BasicElement) new SoundElement(cell);
      throw new Exception(string.Format("Un élément de type inconnu {0} a été trouvé sur la celulle {1}!", (object) elementType, (object) cell.CellId));
    }

    public Cell Cell { get; }

    public abstract void FromRaw(BigEndianReader param1, int param2);

    public abstract int ElementType { get; }
  }
}
