using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
  {
    public new const uint Id = 193;
    public uint grade;

    public override uint TypeId
    {
      get
      {
        return 193;
      }
    }

    public CharacterMinimalPlusLookAndGradeInformations()
    {
    }

    public CharacterMinimalPlusLookAndGradeInformations(
      double id,
      string name,
      uint level,
      EntityLook entityLook,
      int breed,
      uint grade)
      : base(id, name, level, entityLook, breed)
    {
      this.grade = grade;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element grade.");
      writer.WriteVarInt((int) this.grade);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.grade = reader.ReadVarUhInt();
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element of CharacterMinimalPlusLookAndGradeInformations.grade.");
    }
  }
}
