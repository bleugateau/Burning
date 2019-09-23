using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class RecycledItem
  {
    public const uint Id = 547;
    public uint id;
    public uint qty;

    public virtual uint TypeId
    {
      get
      {
        return 547;
      }
    }

    public RecycledItem()
    {
    }

    public RecycledItem(uint id, uint qty)
    {
      this.id = id;
      this.qty = qty;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      if (this.qty < 0U || this.qty > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.qty + ") on element qty.");
      writer.WriteUInt(this.qty);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of RecycledItem.id.");
      this.qty = reader.ReadUInt();
      if (this.qty < 0U || this.qty > uint.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.qty + ") on element of RecycledItem.qty.");
    }
  }
}
