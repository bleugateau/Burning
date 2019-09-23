using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectDate : ObjectEffect
  {
    public new const uint Id = 72;
    public uint year;
    public uint month;
    public uint day;
    public uint hour;
    public uint minute;

    public override uint TypeId
    {
      get
      {
        return 72;
      }
    }

    public ObjectEffectDate()
    {
    }

    public ObjectEffectDate(
      uint actionId,
      uint year,
      uint month,
      uint day,
      uint hour,
      uint minute)
      : base(actionId)
    {
      this.year = year;
      this.month = month;
      this.day = day;
      this.hour = hour;
      this.minute = minute;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.year < 0U)
        throw new Exception("Forbidden value (" + (object) this.year + ") on element year.");
      writer.WriteVarShort((short) this.year);
      if (this.month < 0U)
        throw new Exception("Forbidden value (" + (object) this.month + ") on element month.");
      writer.WriteByte((byte) this.month);
      if (this.day < 0U)
        throw new Exception("Forbidden value (" + (object) this.day + ") on element day.");
      writer.WriteByte((byte) this.day);
      if (this.hour < 0U)
        throw new Exception("Forbidden value (" + (object) this.hour + ") on element hour.");
      writer.WriteByte((byte) this.hour);
      if (this.minute < 0U)
        throw new Exception("Forbidden value (" + (object) this.minute + ") on element minute.");
      writer.WriteByte((byte) this.minute);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.year = (uint) reader.ReadVarUhShort();
      if (this.year < 0U)
        throw new Exception("Forbidden value (" + (object) this.year + ") on element of ObjectEffectDate.year.");
      this.month = (uint) reader.ReadByte();
      if (this.month < 0U)
        throw new Exception("Forbidden value (" + (object) this.month + ") on element of ObjectEffectDate.month.");
      this.day = (uint) reader.ReadByte();
      if (this.day < 0U)
        throw new Exception("Forbidden value (" + (object) this.day + ") on element of ObjectEffectDate.day.");
      this.hour = (uint) reader.ReadByte();
      if (this.hour < 0U)
        throw new Exception("Forbidden value (" + (object) this.hour + ") on element of ObjectEffectDate.hour.");
      this.minute = (uint) reader.ReadByte();
      if (this.minute < 0U)
        throw new Exception("Forbidden value (" + (object) this.minute + ") on element of ObjectEffectDate.minute.");
    }
  }
}
