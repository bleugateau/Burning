using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
  {
    public new const uint Id = 202;
    public uint honor;
    public uint honorGradeFloor;
    public uint honorNextGradeFloor;
    public uint aggressable;

    public override uint TypeId
    {
      get
      {
        return 202;
      }
    }

    public ActorExtendedAlignmentInformations()
    {
    }

    public ActorExtendedAlignmentInformations(
      int alignmentSide,
      uint alignmentValue,
      uint alignmentGrade,
      double characterPower,
      uint honor,
      uint honorGradeFloor,
      uint honorNextGradeFloor,
      uint aggressable)
      : base(alignmentSide, alignmentValue, alignmentGrade, characterPower)
    {
      this.honor = honor;
      this.honorGradeFloor = honorGradeFloor;
      this.honorNextGradeFloor = honorNextGradeFloor;
      this.aggressable = aggressable;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.honor < 0U || this.honor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honor + ") on element honor.");
      writer.WriteVarShort((short) this.honor);
      if (this.honorGradeFloor < 0U || this.honorGradeFloor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honorGradeFloor + ") on element honorGradeFloor.");
      writer.WriteVarShort((short) this.honorGradeFloor);
      if (this.honorNextGradeFloor < 0U || this.honorNextGradeFloor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honorNextGradeFloor + ") on element honorNextGradeFloor.");
      writer.WriteVarShort((short) this.honorNextGradeFloor);
      writer.WriteByte((byte) this.aggressable);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.honor = (uint) reader.ReadVarUhShort();
      if (this.honor < 0U || this.honor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honor + ") on element of ActorExtendedAlignmentInformations.honor.");
      this.honorGradeFloor = (uint) reader.ReadVarUhShort();
      if (this.honorGradeFloor < 0U || this.honorGradeFloor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honorGradeFloor + ") on element of ActorExtendedAlignmentInformations.honorGradeFloor.");
      this.honorNextGradeFloor = (uint) reader.ReadVarUhShort();
      if (this.honorNextGradeFloor < 0U || this.honorNextGradeFloor > 20000U)
        throw new Exception("Forbidden value (" + (object) this.honorNextGradeFloor + ") on element of ActorExtendedAlignmentInformations.honorNextGradeFloor.");
      this.aggressable = (uint) reader.ReadByte();
      if (this.aggressable < 0U)
        throw new Exception("Forbidden value (" + (object) this.aggressable + ") on element of ActorExtendedAlignmentInformations.aggressable.");
    }
  }
}
