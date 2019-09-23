using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PrismInformation
  {
    public const uint Id = 428;
    public uint typeId;
    public uint state;
    public uint nextVulnerabilityDate;
    public uint placementDate;
    public uint rewardTokenCount;

    public virtual uint TypeId
    {
      get
      {
        return 428;
      }
    }

    public PrismInformation()
    {
    }

    public PrismInformation(
      uint typeId,
      uint state,
      uint nextVulnerabilityDate,
      uint placementDate,
      uint rewardTokenCount)
    {
      this.typeId = typeId;
      this.state = state;
      this.nextVulnerabilityDate = nextVulnerabilityDate;
      this.placementDate = placementDate;
      this.rewardTokenCount = rewardTokenCount;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.typeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.typeId + ") on element typeId.");
      writer.WriteByte((byte) this.typeId);
      writer.WriteByte((byte) this.state);
      if (this.nextVulnerabilityDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.nextVulnerabilityDate + ") on element nextVulnerabilityDate.");
      writer.WriteInt((int) this.nextVulnerabilityDate);
      if (this.placementDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.placementDate + ") on element placementDate.");
      writer.WriteInt((int) this.placementDate);
      if (this.rewardTokenCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.rewardTokenCount + ") on element rewardTokenCount.");
      writer.WriteVarInt((int) this.rewardTokenCount);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.typeId = (uint) reader.ReadByte();
      if (this.typeId < 0U)
        throw new Exception("Forbidden value (" + (object) this.typeId + ") on element of PrismInformation.typeId.");
      this.state = (uint) reader.ReadByte();
      if (this.state < 0U)
        throw new Exception("Forbidden value (" + (object) this.state + ") on element of PrismInformation.state.");
      this.nextVulnerabilityDate = (uint) reader.ReadInt();
      if (this.nextVulnerabilityDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.nextVulnerabilityDate + ") on element of PrismInformation.nextVulnerabilityDate.");
      this.placementDate = (uint) reader.ReadInt();
      if (this.placementDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.placementDate + ") on element of PrismInformation.placementDate.");
      this.rewardTokenCount = reader.ReadVarUhInt();
      if (this.rewardTokenCount < 0U)
        throw new Exception("Forbidden value (" + (object) this.rewardTokenCount + ") on element of PrismInformation.rewardTokenCount.");
    }
  }
}
