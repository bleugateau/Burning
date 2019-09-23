using FlatyBot.Common.IO;
using Burning.DofusProtocol.Data.D2P.Utils;
using System;

namespace Burning.DofusProtocol.Data.D2P
{
  public class Fixture
  {
    private Map _map;

    public int FixtureId { get; set; }

    public Point Offset { get; set; }

    public int Hue { get; set; }

    public int RedMultiplier { get; set; }

    public int GreenMultiplier { get; set; }

    public int BlueMultiplier { get; set; }

    public uint Alpha { get; set; }

    public int XScale { get; set; }

    public int YScale { get; set; }

    public int Rotation { get; set; }

    public Fixture(Map param1)
    {
      this._map = param1;
    }

    public void FromRaw(BigEndianReader param1)
    {
      BigEndianReader bigEndianReader = param1;
      try
      {
        this.FixtureId = bigEndianReader.ReadInt();
        this.Offset = new Point()
        {
          X = (int) bigEndianReader.ReadShort(),
          Y = (int) bigEndianReader.ReadShort()
        };
        this.Rotation = (int) bigEndianReader.ReadShort();
        this.XScale = (int) bigEndianReader.ReadShort();
        this.YScale = (int) bigEndianReader.ReadShort();
        this.RedMultiplier = (int) bigEndianReader.ReadByte();
        this.GreenMultiplier = (int) bigEndianReader.ReadByte();
        this.BlueMultiplier = (int) bigEndianReader.ReadByte();
        this.Hue = this.RedMultiplier | this.GreenMultiplier | this.BlueMultiplier;
        this.Alpha = (uint) bigEndianReader.ReadByte();
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        throw;
      }
    }
  }
}
