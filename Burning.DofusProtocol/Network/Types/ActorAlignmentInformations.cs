using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class ActorAlignmentInformations
  {
    public const uint Id = 201;
    public int alignmentSide;
    public uint alignmentValue;
    public uint alignmentGrade;
    public double characterPower;

    public virtual uint TypeId
    {
      get
      {
        return 201;
      }
    }

    public ActorAlignmentInformations()
    {
    }

    public ActorAlignmentInformations(
      int alignmentSide,
      uint alignmentValue,
      uint alignmentGrade,
      double characterPower)
    {
      this.alignmentSide = alignmentSide;
      this.alignmentValue = alignmentValue;
      this.alignmentGrade = alignmentGrade;
      this.characterPower = characterPower;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.alignmentSide);
      if (this.alignmentValue < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentValue + ") on element alignmentValue.");
      writer.WriteByte((byte) this.alignmentValue);
      if (this.alignmentGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentGrade + ") on element alignmentGrade.");
      writer.WriteByte((byte) this.alignmentGrade);
      if (this.characterPower < -9.00719925474099E+15 || this.characterPower > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterPower + ") on element characterPower.");
      writer.WriteDouble(this.characterPower);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.alignmentSide = (int) reader.ReadByte();
      this.alignmentValue = (uint) reader.ReadByte();
      if (this.alignmentValue < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentValue + ") on element of ActorAlignmentInformations.alignmentValue.");
      this.alignmentGrade = (uint) reader.ReadByte();
      if (this.alignmentGrade < 0U)
        throw new Exception("Forbidden value (" + (object) this.alignmentGrade + ") on element of ActorAlignmentInformations.alignmentGrade.");
      this.characterPower = reader.ReadDouble();
      if (this.characterPower < -9.00719925474099E+15 || this.characterPower > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterPower + ") on element of ActorAlignmentInformations.characterPower.");
    }
  }
}
