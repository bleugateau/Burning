using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameActionMark
  {
    public List<GameActionMarkedCell> cells = new List<GameActionMarkedCell>();
    public const uint Id = 351;
    public double markAuthorId;
    public uint markTeamId;
    public uint markSpellId;
    public int markSpellLevel;
    public int markId;
    public int markType;
    public int markimpactCell;
    public bool active;

    public virtual uint TypeId
    {
      get
      {
        return 351;
      }
    }

    public GameActionMark()
    {
    }

    public GameActionMark(
      double markAuthorId,
      uint markTeamId,
      uint markSpellId,
      int markSpellLevel,
      int markId,
      int markType,
      int markimpactCell,
      List<GameActionMarkedCell> cells,
      bool active)
    {
      this.markAuthorId = markAuthorId;
      this.markTeamId = markTeamId;
      this.markSpellId = markSpellId;
      this.markSpellLevel = markSpellLevel;
      this.markId = markId;
      this.markType = markType;
      this.markimpactCell = markimpactCell;
      this.cells = cells;
      this.active = active;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.markAuthorId < -9.00719925474099E+15 || this.markAuthorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.markAuthorId + ") on element markAuthorId.");
      writer.WriteDouble(this.markAuthorId);
      writer.WriteByte((byte) this.markTeamId);
      if (this.markSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.markSpellId + ") on element markSpellId.");
      writer.WriteInt((int) this.markSpellId);
      if (this.markSpellLevel < 1 || this.markSpellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.markSpellLevel + ") on element markSpellLevel.");
      writer.WriteShort((short) this.markSpellLevel);
      writer.WriteShort((short) this.markId);
      writer.WriteByte((byte) this.markType);
      if (this.markimpactCell < -1 || this.markimpactCell > 559)
        throw new Exception("Forbidden value (" + (object) this.markimpactCell + ") on element markimpactCell.");
      writer.WriteShort((short) this.markimpactCell);
      writer.WriteShort((short) this.cells.Count);
      for (int index = 0; index < this.cells.Count; ++index)
        this.cells[index].Serialize(writer);
      writer.WriteBoolean(this.active);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.markAuthorId = reader.ReadDouble();
      if (this.markAuthorId < -9.00719925474099E+15 || this.markAuthorId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.markAuthorId + ") on element of GameActionMark.markAuthorId.");
      this.markTeamId = (uint) reader.ReadByte();
      if (this.markTeamId < 0U)
        throw new Exception("Forbidden value (" + (object) this.markTeamId + ") on element of GameActionMark.markTeamId.");
      this.markSpellId = (uint) reader.ReadInt();
      if (this.markSpellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.markSpellId + ") on element of GameActionMark.markSpellId.");
      this.markSpellLevel = (int) reader.ReadShort();
      if (this.markSpellLevel < 1 || this.markSpellLevel > 200)
        throw new Exception("Forbidden value (" + (object) this.markSpellLevel + ") on element of GameActionMark.markSpellLevel.");
      this.markId = (int) reader.ReadShort();
      this.markType = (int) reader.ReadByte();
      this.markimpactCell = (int) reader.ReadShort();
      if (this.markimpactCell < -1 || this.markimpactCell > 559)
        throw new Exception("Forbidden value (" + (object) this.markimpactCell + ") on element of GameActionMark.markimpactCell.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        GameActionMarkedCell actionMarkedCell = new GameActionMarkedCell();
        actionMarkedCell.Deserialize(reader);
        this.cells.Add(actionMarkedCell);
      }
      this.active = reader.ReadBoolean();
    }
  }
}
