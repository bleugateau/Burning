using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
  {
    public new const uint Id = 6;
    public int monsterId;
    public uint grade;

    public override uint TypeId
    {
      get
      {
        return 6;
      }
    }

    public FightTeamMemberMonsterInformations()
    {
    }

    public FightTeamMemberMonsterInformations(double id, int monsterId, uint grade)
      : base(id)
    {
      this.monsterId = monsterId;
      this.grade = grade;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.monsterId);
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element grade.");
      writer.WriteByte((byte) this.grade);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.monsterId = reader.ReadInt();
      this.grade = (uint) reader.ReadByte();
      if (this.grade < 0U)
        throw new Exception("Forbidden value (" + (object) this.grade + ") on element of FightTeamMemberMonsterInformations.grade.");
    }
  }
}
