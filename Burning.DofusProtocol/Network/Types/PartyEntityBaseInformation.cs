using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PartyEntityBaseInformation
  {
    public const uint Id = 552;
    public uint indexId;
    public uint entityModelId;
    public EntityLook entityLook;

    public virtual uint TypeId
    {
      get
      {
        return 552;
      }
    }

    public PartyEntityBaseInformation()
    {
    }

    public PartyEntityBaseInformation(uint indexId, uint entityModelId, EntityLook entityLook)
    {
      this.indexId = indexId;
      this.entityModelId = entityModelId;
      this.entityLook = entityLook;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.indexId < 0U)
        throw new Exception("Forbidden value (" + (object) this.indexId + ") on element indexId.");
      writer.WriteByte((byte) this.indexId);
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element entityModelId.");
      writer.WriteByte((byte) this.entityModelId);
      this.entityLook.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.indexId = (uint) reader.ReadByte();
      if (this.indexId < 0U)
        throw new Exception("Forbidden value (" + (object) this.indexId + ") on element of PartyEntityBaseInformation.indexId.");
      this.entityModelId = (uint) reader.ReadByte();
      if (this.entityModelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.entityModelId + ") on element of PartyEntityBaseInformation.entityModelId.");
      this.entityLook = new EntityLook();
      this.entityLook.Deserialize(reader);
    }
  }
}
