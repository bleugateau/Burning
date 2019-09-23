using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AnomalySubareaInformation
  {
    public const uint Id = 565;
    public uint subAreaId;
    public int rewardRate;
    public bool hasAnomaly;
    public double anomalyClosingTime;

    public virtual uint TypeId
    {
      get
      {
        return 565;
      }
    }

    public AnomalySubareaInformation()
    {
    }

    public AnomalySubareaInformation(
      uint subAreaId,
      int rewardRate,
      bool hasAnomaly,
      double anomalyClosingTime)
    {
      this.subAreaId = subAreaId;
      this.rewardRate = rewardRate;
      this.hasAnomaly = hasAnomaly;
      this.anomalyClosingTime = anomalyClosingTime;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      writer.WriteVarShort((short) this.rewardRate);
      writer.WriteBoolean(this.hasAnomaly);
      if (this.anomalyClosingTime < 0.0 || this.anomalyClosingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.anomalyClosingTime + ") on element anomalyClosingTime.");
      writer.WriteVarLong((long) this.anomalyClosingTime);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of AnomalySubareaInformation.subAreaId.");
      this.rewardRate = (int) reader.ReadVarShort();
      this.hasAnomaly = reader.ReadBoolean();
      this.anomalyClosingTime = (double) reader.ReadVarUhLong();
      if (this.anomalyClosingTime < 0.0 || this.anomalyClosingTime > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.anomalyClosingTime + ") on element of AnomalySubareaInformation.anomalyClosingTime.");
    }
  }
}
