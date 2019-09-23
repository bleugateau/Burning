using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class JobExperience
  {
    public const uint Id = 98;
    public uint jobId;
    public uint jobLevel;
    public double jobXP;
    public double jobXpLevelFloor;
    public double jobXpNextLevelFloor;

    public virtual uint TypeId
    {
      get
      {
        return 98;
      }
    }

    public JobExperience()
    {
    }

    public JobExperience(
      uint jobId,
      uint jobLevel,
      double jobXP,
      double jobXpLevelFloor,
      double jobXpNextLevelFloor)
    {
      this.jobId = jobId;
      this.jobLevel = jobLevel;
      this.jobXP = jobXP;
      this.jobXpLevelFloor = jobXpLevelFloor;
      this.jobXpNextLevelFloor = jobXpNextLevelFloor;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element jobId.");
      writer.WriteByte((byte) this.jobId);
      if (this.jobLevel < 0U || this.jobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.jobLevel + ") on element jobLevel.");
      writer.WriteByte((byte) this.jobLevel);
      if (this.jobXP < 0.0 || this.jobXP > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXP + ") on element jobXP.");
      writer.WriteVarLong((long) this.jobXP);
      if (this.jobXpLevelFloor < 0.0 || this.jobXpLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXpLevelFloor + ") on element jobXpLevelFloor.");
      writer.WriteVarLong((long) this.jobXpLevelFloor);
      if (this.jobXpNextLevelFloor < 0.0 || this.jobXpNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXpNextLevelFloor + ") on element jobXpNextLevelFloor.");
      writer.WriteVarLong((long) this.jobXpNextLevelFloor);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.jobId = (uint) reader.ReadByte();
      if (this.jobId < 0U)
        throw new Exception("Forbidden value (" + (object) this.jobId + ") on element of JobExperience.jobId.");
      this.jobLevel = (uint) reader.ReadByte();
      if (this.jobLevel < 0U || this.jobLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.jobLevel + ") on element of JobExperience.jobLevel.");
      this.jobXP = (double) reader.ReadVarUhLong();
      if (this.jobXP < 0.0 || this.jobXP > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXP + ") on element of JobExperience.jobXP.");
      this.jobXpLevelFloor = (double) reader.ReadVarUhLong();
      if (this.jobXpLevelFloor < 0.0 || this.jobXpLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXpLevelFloor + ") on element of JobExperience.jobXpLevelFloor.");
      this.jobXpNextLevelFloor = (double) reader.ReadVarUhLong();
      if (this.jobXpNextLevelFloor < 0.0 || this.jobXpNextLevelFloor > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.jobXpNextLevelFloor + ") on element of JobExperience.jobXpNextLevelFloor.");
    }
  }
}
