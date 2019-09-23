using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class SubEntity
  {
    public const uint Id = 54;
    public uint bindingPointCategory;
    public uint bindingPointIndex;
    public EntityLook subEntityLook;

    public virtual uint TypeId
    {
      get
      {
        return 54;
      }
    }

    public SubEntity()
    {
    }

    public SubEntity(uint bindingPointCategory, uint bindingPointIndex, EntityLook subEntityLook)
    {
      this.bindingPointCategory = bindingPointCategory;
      this.bindingPointIndex = bindingPointIndex;
      this.subEntityLook = subEntityLook;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.bindingPointCategory);
      if (this.bindingPointIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.bindingPointIndex + ") on element bindingPointIndex.");
      writer.WriteByte((byte) this.bindingPointIndex);
      this.subEntityLook.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.bindingPointCategory = (uint) reader.ReadByte();
      if (this.bindingPointCategory < 0U)
        throw new Exception("Forbidden value (" + (object) this.bindingPointCategory + ") on element of SubEntity.bindingPointCategory.");
      this.bindingPointIndex = (uint) reader.ReadByte();
      if (this.bindingPointIndex < 0U)
        throw new Exception("Forbidden value (" + (object) this.bindingPointIndex + ") on element of SubEntity.bindingPointIndex.");
      this.subEntityLook = new EntityLook();
      this.subEntityLook.Deserialize(reader);
    }
  }
}
