using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class Shortcut
  {
    public const uint Id = 369;
    public uint slot;

    public virtual uint TypeId
    {
      get
      {
        return 369;
      }
    }

    public Shortcut()
    {
    }

    public Shortcut(uint slot)
    {
      this.slot = slot;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.slot < 0U || this.slot > 99U)
        throw new Exception("Forbidden value (" + (object) this.slot + ") on element slot.");
      writer.WriteByte((byte) this.slot);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.slot = (uint) reader.ReadByte();
      if (this.slot < 0U || this.slot > 99U)
        throw new Exception("Forbidden value (" + (object) this.slot + ") on element of Shortcut.slot.");
    }
  }
}
