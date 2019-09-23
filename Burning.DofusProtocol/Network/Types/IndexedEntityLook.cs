using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class IndexedEntityLook
  {
    public const uint Id = 405;
    public EntityLook look;
    public uint index;

    public virtual uint TypeId
    {
      get
      {
        return 405;
      }
    }

    public IndexedEntityLook()
    {
    }

    public IndexedEntityLook(EntityLook look, uint index)
    {
      this.look = look;
      this.index = index;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      this.look.Serialize(writer);
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element index.");
      writer.WriteByte((byte) this.index);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.look = new EntityLook();
      this.look.Deserialize(reader);
      this.index = (uint) reader.ReadByte();
      if (this.index < 0U)
        throw new Exception("Forbidden value (" + (object) this.index + ") on element of IndexedEntityLook.index.");
    }
  }
}
