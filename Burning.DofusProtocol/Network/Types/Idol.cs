using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class Idol
  {
    public const uint Id = 489;
    public uint id;
    public uint xpBonusPercent;
    public uint dropBonusPercent;

    public virtual uint TypeId
    {
      get
      {
        return 489;
      }
    }

    public Idol()
    {
    }

    public Idol(uint id, uint xpBonusPercent, uint dropBonusPercent)
    {
      this.id = id;
      this.xpBonusPercent = xpBonusPercent;
      this.dropBonusPercent = dropBonusPercent;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      if (this.xpBonusPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBonusPercent + ") on element xpBonusPercent.");
      writer.WriteVarShort((short) this.xpBonusPercent);
      if (this.dropBonusPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBonusPercent + ") on element dropBonusPercent.");
      writer.WriteVarShort((short) this.dropBonusPercent);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of Idol.id.");
      this.xpBonusPercent = (uint) reader.ReadVarUhShort();
      if (this.xpBonusPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.xpBonusPercent + ") on element of Idol.xpBonusPercent.");
      this.dropBonusPercent = (uint) reader.ReadVarUhShort();
      if (this.dropBonusPercent < 0U)
        throw new Exception("Forbidden value (" + (object) this.dropBonusPercent + ") on element of Idol.dropBonusPercent.");
    }
  }
}
