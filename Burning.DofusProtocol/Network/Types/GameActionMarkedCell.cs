using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameActionMarkedCell
  {
    public const uint Id = 85;
    public uint cellId;
    public int zoneSize;
    public int cellColor;
    public int cellsType;

    public virtual uint TypeId
    {
      get
      {
        return 85;
      }
    }

    public GameActionMarkedCell()
    {
    }

    public GameActionMarkedCell(uint cellId, int zoneSize, int cellColor, int cellsType)
    {
      this.cellId = cellId;
      this.zoneSize = zoneSize;
      this.cellColor = cellColor;
      this.cellsType = cellsType;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
      writer.WriteByte((byte) this.zoneSize);
      writer.WriteInt(this.cellColor);
      writer.WriteByte((byte) this.cellsType);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of GameActionMarkedCell.cellId.");
      this.zoneSize = (int) reader.ReadByte();
      this.cellColor = reader.ReadInt();
      this.cellsType = (int) reader.ReadByte();
    }
  }
}
