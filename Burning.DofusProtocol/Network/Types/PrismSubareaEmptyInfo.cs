using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PrismSubareaEmptyInfo
  {
    public const uint Id = 438;
    public uint subAreaId;
    public uint allianceId;

    public virtual uint TypeId
    {
      get
      {
        return 438;
      }
    }

    public PrismSubareaEmptyInfo()
    {
    }

    public PrismSubareaEmptyInfo(uint subAreaId, uint allianceId)
    {
      this.subAreaId = subAreaId;
      this.allianceId = allianceId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element allianceId.");
      writer.WriteVarInt((int) this.allianceId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismSubareaEmptyInfo.subAreaId.");
      this.allianceId = reader.ReadVarUhInt();
      if (this.allianceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.allianceId + ") on element of PrismSubareaEmptyInfo.allianceId.");
    }
  }
}
