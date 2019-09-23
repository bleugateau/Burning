using FlatyBot.Common.Extensions;
using FlatyBot.Common.IO;
using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Data.D2P.Utils;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.IO;

namespace Burning.DofusProtocol.Data.D2P
{
  public class Map
  {
    public int ZoomScale = 1;
    public int GroundCacheCurrentlyUsed;
    public bool IsUsingNewMovementSystem;

    public int MapVersion { get; set; }

    public bool Encrypted { get; set; }

    public uint EncryptionVersion { get; set; }

    public int GroundCrc { get; set; }

    public int ZoomOffsetX { get; set; }

    public int ZoomOffsetY { get; set; }

    public int Id { get; set; }

    public int RelativeId { get; set; }

    public int MapType { get; set; }

    public int BackgroundsCount { get; set; }

    public Fixture[] BackgroundsFixtures { get; set; }

    public int ForegroundsCount { get; set; }

    public Fixture[] ForegroundFixtures { get; set; }

    public int SubAreaId { get; set; }

    public int ShadowBonusOnEntities { get; set; }

    public uint GridColor { get; set; }

    public uint BackgroundColor { get; set; }

    public int BackgroundRed { get; set; }

    public int BackgroundGreen { get; set; }

    public int BackgroundBlue { get; set; }

    public int BackgroundAlpha { get; set; }

    public int TopNeighbourId { get; set; }

    public int BottomNeighbourId { get; set; }

    public int LeftNeighbourId { get; set; }

    public int RightNeighbourId { get; set; }

    public bool UseLowPassFilter { get; set; }

    public bool UseReverb { get; set; }

    public int PresetId { get; set; }

    public int CellsCount { get; set; }

    public int LayersCount { get; set; }

    public Layer[] Layers { get; set; }

    public CellData[] Cells { get; set; }

    public List<uint> TopArrowCell { get; set; }

    public List<uint> LeftArrowCell { get; set; }

    public List<uint> BottomArrowCell { get; set; }

    public List<uint> RightArrowCell { get; set; }

    public int TacticalModeTemplateId { get; set; }

    public int X
    {
      get
      {
        return Singleton<ObjectDataManager>.Instance.Get<MapPosition>(this.Id, false).PosX;
      }
    }

    public int Y
    {
      get
      {
        return Singleton<ObjectDataManager>.Instance.Get<MapPosition>(this.Id, false).PosY;
      }
    }

    public Map()
    {
      this.TopArrowCell = new List<uint>();
      this.LeftArrowCell = new List<uint>();
      this.BottomArrowCell = new List<uint>();
      this.RightArrowCell = new List<uint>();
    }

    public bool IsLineOfSight(int cellId)
    {
      if (cellId >= 0 && cellId < this.CellsCount)
        return this.Cells[cellId].Los;
      return false;
    }

    public bool IsWalkable(int cellId)
    {
      if (cellId >= 0 && cellId < this.CellsCount && this.Cells[cellId].Mov)
        return !this.Cells[cellId].NonWalkableDuringFight;
      return false;
    }

    public void FromRaw(BigEndianReader param1, byte[] param2)
    {
      int num1 = -1;
      BigEndianReader bigEndianReader = param1;
      byte[] numArray = param2;
      try
      {
        if (bigEndianReader.ReadByte() != (byte) 77)
          throw new Exception("Unknown file format.");
        this.MapVersion = (int) bigEndianReader.ReadByte();
        this.Id = bigEndianReader.ReadInt();
        if (this.MapVersion >= 7)
        {
          this.Encrypted = bigEndianReader.ReadBoolean();
          this.EncryptionVersion = (uint) bigEndianReader.ReadByte();
          int n = bigEndianReader.ReadInt();
          if (this.Encrypted)
          {
            if (numArray.Length < 1)
              throw new Exception("Map decryption key is empty");
            byte[] buffer = bigEndianReader.ReadBytes(n);
            for (int index = 0; index < buffer.Length; ++index)
              buffer[index] = (byte) ((uint) buffer[index] ^ (uint) numArray[index % numArray.Length]);
            bigEndianReader = new BigEndianReader((Stream) new MemoryStream(buffer));
          }
        }
        this.RelativeId = bigEndianReader.ReadInt();
        this.MapType = (int) bigEndianReader.ReadByte();
        this.SubAreaId = bigEndianReader.ReadInt();
        this.TopNeighbourId = bigEndianReader.ReadInt();
        this.BottomNeighbourId = bigEndianReader.ReadInt();
        this.LeftNeighbourId = bigEndianReader.ReadInt();
        this.RightNeighbourId = bigEndianReader.ReadInt();
        this.ShadowBonusOnEntities = bigEndianReader.ReadInt();
        if (this.MapVersion >= 9)
        {
          int num2 = bigEndianReader.ReadInt();
          this.BackgroundAlpha = (int) (((long) num2 & 4278190080L) >> 32);
          this.BackgroundRed = (num2 & 16711680) >> 16;
          this.BackgroundGreen = (num2 & 65280) >> 8;
          this.BackgroundBlue = num2 & (int) byte.MaxValue;
          int num3 = bigEndianReader.ReadInt();
          this.GridColor = (uint) ((int) (((long) num3 & 4278190080L) >> 32) & (int) byte.MaxValue | ((num3 & 16711680) >> 16 & (int) byte.MaxValue) << 16 | ((num3 & 65280) >> 8 & (int) byte.MaxValue) << 8 | num3 & (int) byte.MaxValue & (int) byte.MaxValue);
        }
        else if (this.MapVersion >= 3)
        {
          this.BackgroundRed = (int) bigEndianReader.ReadByte();
          this.BackgroundGreen = (int) bigEndianReader.ReadByte();
          this.BackgroundBlue = (int) bigEndianReader.ReadByte();
        }
        this.BackgroundColor = (uint) (this.BackgroundAlpha & (int) byte.MaxValue | (this.BackgroundRed & (int) byte.MaxValue) << 16 | (this.BackgroundGreen & (int) byte.MaxValue) << 8 | this.BackgroundBlue & (int) byte.MaxValue);
        if (this.MapVersion >= 4)
        {
          this.ZoomScale = (int) bigEndianReader.ReadShort() / 100;
          this.ZoomOffsetX = (int) bigEndianReader.ReadShort();
          this.ZoomOffsetY = (int) bigEndianReader.ReadShort();
          if (this.ZoomScale < 1)
          {
            this.ZoomScale = 1;
            this.ZoomOffsetY = 0;
            this.ZoomOffsetX = 0;
          }
        }
        if (this.MapVersion > 10)
          this.TacticalModeTemplateId = bigEndianReader.ReadInt();
        this.UseLowPassFilter = bigEndianReader.ReadByte() == (byte) 1;
        this.UseReverb = bigEndianReader.ReadByte() == (byte) 1;
        this.PresetId = !this.UseReverb ? -1 : bigEndianReader.ReadInt();
        this.BackgroundsCount = (int) bigEndianReader.ReadByte();
        this.BackgroundsFixtures = new Fixture[this.BackgroundsCount];
        for (int index = 0; index < this.BackgroundsCount; ++index)
        {
          Fixture fixture = new Fixture(this);
          fixture.FromRaw(bigEndianReader);
          this.BackgroundsFixtures[index] = fixture;
        }
        this.ForegroundsCount = (int) bigEndianReader.ReadByte();
        this.ForegroundFixtures = new Fixture[this.ForegroundsCount];
        for (int index = 0; index < this.ForegroundsCount; ++index)
        {
          Fixture fixture = new Fixture(this);
          fixture.FromRaw(bigEndianReader);
          this.ForegroundFixtures[index] = fixture;
        }
        this.CellsCount = Constants.MapCellsCount;
        bigEndianReader.ReadInt();
        this.GroundCrc = bigEndianReader.ReadInt();
        this.LayersCount = (int) bigEndianReader.ReadByte();
        this.Layers = new Layer[this.LayersCount];
        for (int index = 0; index < this.LayersCount; ++index)
        {
          Layer layer = new Layer(this);
          layer.FromRaw(bigEndianReader, this.MapVersion);
          this.Layers[index] = layer;
        }
        this.Cells = new CellData[this.CellsCount];
        for (int index = 0; index < this.CellsCount; ++index)
        {
          CellData cellData = new CellData(this, (uint) index);
          cellData.FromRaw(bigEndianReader);
          if (num1 == -1)
            num1 = (int) cellData.MoveZone;
          if ((long) cellData.MoveZone != (long) num1)
            this.IsUsingNewMovementSystem = true;
          this.Cells[index] = cellData;
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
