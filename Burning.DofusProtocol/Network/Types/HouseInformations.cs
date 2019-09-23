using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HouseInformations
  {
    public const uint Id = 111;
    public uint houseId;
    public uint modelId;

    public virtual uint TypeId
    {
      get
      {
        return 111;
      }
    }

    public HouseInformations()
    {
    }

    public HouseInformations(uint houseId, uint modelId)
    {
      this.houseId = houseId;
      this.modelId = modelId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element modelId.");
      writer.WriteVarShort((short) this.modelId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseInformations.houseId.");
      this.modelId = (uint) reader.ReadVarUhShort();
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element of HouseInformations.modelId.");
    }
  }
}
