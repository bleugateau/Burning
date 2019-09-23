using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectEffectDuration : ObjectEffect
  {
    public new const uint Id = 75;
    public uint days;
    public uint hours;
    public uint minutes;

    public override uint TypeId
    {
      get
      {
        return 75;
      }
    }

    public ObjectEffectDuration()
    {
    }

    public ObjectEffectDuration(uint actionId, uint days, uint hours, uint minutes)
      : base(actionId)
    {
      this.days = days;
      this.hours = hours;
      this.minutes = minutes;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.days < 0U)
        throw new Exception("Forbidden value (" + (object) this.days + ") on element days.");
      writer.WriteVarShort((short) this.days);
      if (this.hours < 0U)
        throw new Exception("Forbidden value (" + (object) this.hours + ") on element hours.");
      writer.WriteByte((byte) this.hours);
      if (this.minutes < 0U)
        throw new Exception("Forbidden value (" + (object) this.minutes + ") on element minutes.");
      writer.WriteByte((byte) this.minutes);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.days = (uint) reader.ReadVarUhShort();
      if (this.days < 0U)
        throw new Exception("Forbidden value (" + (object) this.days + ") on element of ObjectEffectDuration.days.");
      this.hours = (uint) reader.ReadByte();
      if (this.hours < 0U)
        throw new Exception("Forbidden value (" + (object) this.hours + ") on element of ObjectEffectDuration.hours.");
      this.minutes = (uint) reader.ReadByte();
      if (this.minutes < 0U)
        throw new Exception("Forbidden value (" + (object) this.minutes + ") on element of ObjectEffectDuration.minutes.");
    }
  }
}
