using FlatyBot.Common.IO;
using Burning.DofusProtocol.Data.D2P.Utils;
using System;

namespace Burning.DofusProtocol.Data.D2P.Elements
{
  public class GraphicalElement : BasicElement
  {
    public int ElementId { get; private set; }

    public ColorMultiplicator Hue { get; private set; }

    public ColorMultiplicator Shadow { get; private set; }

    public ColorMultiplicator FinalTeint { get; private set; }

    public Point Offset { get; private set; }

    public Point PixelOffset { get; private set; }

    public int Altitude { get; private set; }

    public uint Identifier { get; private set; }

    public GraphicalElement(Cell param1)
      : base(param1)
    {
    }

    public override int ElementType
    {
      get
      {
        return 2;
      }
    }

    public ColorMultiplicator GetColorMultiplicator
    {
      get
      {
        return this.FinalTeint;
      }
    }

    private void CalculateFinalTeint()
    {
      this.FinalTeint = new ColorMultiplicator(ColorMultiplicator.Clamp((this.Hue.Red + this.Shadow.Red + 128) * 2, 0, 512), ColorMultiplicator.Clamp((this.Hue.Green + this.Shadow.Green + 128) * 2, 0, 512), ColorMultiplicator.Clamp((this.Hue.Blue + this.Shadow.Blue + 128) * 2, 0, 512), true);
    }

    public override void FromRaw(BigEndianReader param1, int param2)
    {
      BigEndianReader bigEndianReader = param1;
      int num = param2;
      try
      {
        this.ElementId = bigEndianReader.ReadInt();
        this.Hue = new ColorMultiplicator((int) bigEndianReader.ReadByte(), (int) bigEndianReader.ReadByte(), (int) bigEndianReader.ReadByte(), false);
        this.Shadow = new ColorMultiplicator((int) bigEndianReader.ReadByte(), (int) bigEndianReader.ReadByte(), (int) bigEndianReader.ReadByte(), false);
        this.Offset = new Point();
        this.PixelOffset = new Point();
        if (num <= 4)
        {
          this.Offset.X = (int) bigEndianReader.ReadByte();
          this.Offset.Y = (int) bigEndianReader.ReadByte();
          this.PixelOffset.X = this.Offset.X * Constants.CellHalfWidth;
          this.PixelOffset.Y = (int) ((double) this.Offset.Y * Constants.CellHalfHeight);
        }
        else
        {
          this.PixelOffset.X = (int) bigEndianReader.ReadShort();
          this.PixelOffset.Y = (int) bigEndianReader.ReadShort();
          this.Offset.X = this.PixelOffset.X / Constants.CellHalfWidth;
          this.Offset.Y = (int) ((double) this.PixelOffset.Y / Constants.CellHalfHeight);
        }
        this.Altitude = (int) bigEndianReader.ReadByte();
        this.Identifier = (uint) bigEndianReader.ReadInt();
        this.CalculateFinalTeint();
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        throw;
      }
    }
  }
}
