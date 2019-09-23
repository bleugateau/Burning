using FlatyBot.Common.IO;
using System;
using System.Drawing;

namespace Burning.DofusProtocol.Data.D2P
{
  public class CellData
  {
    private static readonly Point[] OrthogonalGridReference = new Point[560];
    public int _losmov = 3;
    public const uint Height = 20;
    public const uint MapSize = 560;
    public const uint Width = 14;
    public bool Mov;
    public bool Los;
    public bool NonWalkableDuringFight;
    private Point? _point;
    public byte LinkedZone;
    private readonly Map _map;
    private int _arrow;
    private static bool _initialized;

    public uint Id { get; set; }

    public int Speed { get; set; }

    public uint MapChangeData { get; set; }

    public uint MoveZone { get; set; }

    public int Floor { get; set; }

    public bool Red { get; set; }

    public bool Blue { get; set; }

    public bool FarmCell { get; set; }

    public bool HavenbagCell { get; set; }

    public bool Visible { get; set; }

    public bool NonWalkableDuringRp { get; set; }

    public bool UseTopArrow
    {
      get
      {
        return (uint) (this._arrow & 1) > 0U;
      }
    }

    public bool UseBottomArrow
    {
      get
      {
        return (uint) (this._arrow & 2) > 0U;
      }
    }

    public bool UseRightArrow
    {
      get
      {
        return (uint) (this._arrow & 4) > 0U;
      }
    }

    public bool UseLeftArrow
    {
      get
      {
        return (uint) (this._arrow & 8) > 0U;
      }
    }

    public bool HasLinkedZoneRP
    {
      get
      {
        if (this.Mov)
          return !this.FarmCell;
        return false;
      }
    }

    public int LinkedZoneRP
    {
      get
      {
        return ((int) this.LinkedZone & 240) >> 4;
      }
    }

    public bool HasLinkedZoneFight
    {
      get
      {
        if (this.Mov && !this.NonWalkableDuringFight && !this.FarmCell)
          return !this.HavenbagCell;
        return false;
      }
    }

    public int LinkedZoneFight
    {
      get
      {
        return (int) this.LinkedZone & 15;
      }
    }

    public Point Point
    {
      get
      {
        return this._point ?? (this._point = new Point?(CellData.GetPointFromCell((short) this.Id))).Value;
      }
    }

    public int X
    {
      get
      {
        return this.Point.X;
      }
    }

    public int Y
    {
      get
      {
        return this.Point.Y;
      }
    }

    public bool IsWalkable(bool isFightMode)
    {
      return (this._losmov & (isFightMode ? 5 : 1)) == 1;
    }

    public bool isObstacle()
    {
      if (!this.Mov)
        return !this.Los;
      return false;
    }

    public CellData(Map param1, uint param2)
    {
      this.Id = param2;
      this._map = param1;
    }

    public static Point GetPointFromCell(short id)
    {
      if (!CellData._initialized)
        CellData.InitializeStaticGrid();
      if (id < (short) 0 || id > (short) 560)
        throw new IndexOutOfRangeException("Cell identifier out of bounds (" + (object) id + ").");
      return CellData.OrthogonalGridReference[(int) id];
    }

    private static void InitializeStaticGrid()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      for (int index1 = 0; index1 < 20; ++index1)
      {
        for (int index2 = 0; index2 < 14; ++index2)
          CellData.OrthogonalGridReference[num3++] = new Point(num1 + index2, num2 + index2);
        ++num1;
        for (int index2 = 0; index2 < 14; ++index2)
          CellData.OrthogonalGridReference[num3++] = new Point(num1 + index2, num2 + index2);
        --num2;
      }
      CellData._initialized = true;
    }

    public void FromRaw(BigEndianReader param1)
    {
      BigEndianReader bigEndianReader = param1;
      try
      {
        this.Floor = (int) bigEndianReader.ReadByte() * 10;
        if (this.Floor == -1280)
          return;
        if (this._map.MapVersion >= 9)
        {
          int num = (int) bigEndianReader.ReadShort();
          this.Mov = (num & 1) == 0;
          this.NonWalkableDuringFight = (uint) (num & 2) > 0U;
          this.NonWalkableDuringRp = (uint) (num & 4) > 0U;
          this.Los = (num & 8) == 0;
          this.Blue = (uint) (num & 16) > 0U;
          this.Red = (uint) (num & 32) > 0U;
          this.Visible = (uint) (num & 64) > 0U;
          this.FarmCell = (uint) (num & 128) > 0U;
          bool flag1;
          bool flag2;
          bool flag3;
          bool flag4;
          if (this._map.MapVersion >= 10)
          {
            this.HavenbagCell = (uint) (num & 256) > 0U;
            flag1 = (uint) (num & 512) > 0U;
            flag2 = (uint) (num & 1024) > 0U;
            flag3 = (uint) (num & 2048) > 0U;
            flag4 = (uint) (num & 4096) > 0U;
          }
          else
          {
            flag1 = (uint) (num & 256) > 0U;
            flag2 = (uint) (num & 512) > 0U;
            flag3 = (uint) (num & 1024) > 0U;
            flag4 = (uint) (num & 2048) > 0U;
          }
          if (flag1)
            this._map.TopArrowCell.Add(this.Id);
          if (flag2)
            this._map.BottomArrowCell.Add(this.Id);
          if (flag3)
            this._map.RightArrowCell.Add(this.Id);
          if (flag4)
            this._map.LeftArrowCell.Add(this.Id);
        }
        else
        {
          this._losmov = (int) bigEndianReader.ReadByte();
          this.Los = (this._losmov & 2) >> 1 == 1;
          this.Mov = (this._losmov & 1) == 1;
          this.Visible = (this._losmov & 64) >> 6 == 1;
          this.FarmCell = (this._losmov & 32) >> 5 == 1;
          this.Blue = (this._losmov & 16) >> 4 == 1;
          this.Red = (this._losmov & 8) >> 3 == 1;
          this.NonWalkableDuringRp = (this._losmov & 128) >> 7 == 1;
          this.NonWalkableDuringFight = (this._losmov & 4) >> 2 == 1;
        }
        this.Speed = (int) bigEndianReader.ReadByte();
        this.MapChangeData = (uint) bigEndianReader.ReadByte();
        if (this._map.MapVersion > 5)
          this.MoveZone = (uint) bigEndianReader.ReadByte();
        if (this._map.MapVersion > 10 && (this.HasLinkedZoneRP || this.HasLinkedZoneFight))
          this.LinkedZone = bigEndianReader.ReadByte();
        if (this._map.MapVersion <= 7 || this._map.MapVersion >= 9)
          return;
        this._arrow = 15 & (int) bigEndianReader.ReadByte();
        if (this.UseTopArrow)
          this._map.TopArrowCell.Add(this.Id);
        if (this.UseBottomArrow)
          this._map.BottomArrowCell.Add(this.Id);
        if (this.UseLeftArrow)
          this._map.LeftArrowCell.Add(this.Id);
        if (!this.UseRightArrow)
          return;
        this._map.RightArrowCell.Add(this.Id);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
        throw;
      }
    }

    public bool Walkable
    {
      get
      {
        return this.Mov;
      }
    }
  }
}
