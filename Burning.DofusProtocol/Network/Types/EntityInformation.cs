using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class EntityInformation
  {
    public const uint Id = 546;
    public uint id;
    public uint experience;
    public bool status;

    public virtual uint TypeId
    {
      get
      {
        return 546;
      }
    }

    public EntityInformation()
    {
    }

    public EntityInformation(uint id, uint experience, bool status)
    {
      this.id = id;
      this.experience = experience;
      this.status = status;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      if (this.experience < 0U)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element experience.");
      writer.WriteVarInt((int) this.experience);
      writer.WriteBoolean(this.status);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of EntityInformation.id.");
      this.experience = reader.ReadVarUhInt();
      if (this.experience < 0U)
        throw new Exception("Forbidden value (" + (object) this.experience + ") on element of EntityInformation.experience.");
      this.status = reader.ReadBoolean();
    }
  }
}
