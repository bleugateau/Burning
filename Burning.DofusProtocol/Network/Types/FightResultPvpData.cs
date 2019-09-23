using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightResultPvpData : FightResultAdditionalData
  {
    public new const uint Id = 190;
    public uint grade;
    public uint minHonorForGrade;
    public uint maxHonorForGrade;
    public uint honor;
    public int honorDelta;

    public override uint TypeId
    {
      get
      {
        return 190;
      }
    }

    public FightResultPvpData()
    {
    }

    public FightResultPvpData(
      uint grade,
      uint minHonorForGrade,
      uint maxHonorForGrade,
      uint honor,
      int honorDelta)
    {
      this.grade = grade;
      this.minHonorForGrade = minHonorForGrade;
      this.maxHonorForGrade = maxHonorForGrade;
      this.honor = honor;
      this.honorDelta = honorDelta;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.grade < 0U || this.grade > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element grade.");
      writer.WriteByte((byte) this.grade);
      if (this.minHonorForGrade < 0U || this.minHonorForGrade > 20000U)
        throw new Exception("Forbidden value (" + (object) this.minHonorForGrade + ") on element minHonorForGrade.");
      writer.WriteVarShort((short) this.minHonorForGrade);
      if (this.maxHonorForGrade < 0U || this.maxHonorForGrade > 20000U)
        throw new Exception("Forbidden value (" + (object) this.maxHonorForGrade + ") on element maxHonorForGrade.");
      writer.WriteVarShort((short) this.maxHonorForGrade);
      if (this.honor < 0U || this.honor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honor + ") on element honor.");
      writer.WriteVarShort((short) this.honor);
      writer.WriteVarShort((short) this.honorDelta);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.grade = (uint) reader.ReadByte();
      if (this.grade < 0U || this.grade > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element of FightResultPvpData.grade.");
      this.minHonorForGrade = (uint) reader.ReadVarUhShort();
      if (this.minHonorForGrade < 0U || this.minHonorForGrade > 20000U)
        throw new Exception("Forbidden value (" + (object) this.minHonorForGrade + ") on element of FightResultPvpData.minHonorForGrade.");
      this.maxHonorForGrade = (uint) reader.ReadVarUhShort();
      if (this.maxHonorForGrade < 0U || this.maxHonorForGrade > 20000U)
        throw new Exception("Forbidden value (" + (object) this.maxHonorForGrade + ") on element of FightResultPvpData.maxHonorForGrade.");
      this.honor = (uint) reader.ReadVarUhShort();
      if (this.honor < 0U || this.honor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honor + ") on element of FightResultPvpData.honor.");
      this.honorDelta = (int) reader.ReadVarShort();
    }
  }
}
