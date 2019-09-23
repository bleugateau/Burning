using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
  {
    public new const uint Id = 13;
    public string name;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 13;
      }
    }

    public FightTeamMemberCharacterInformations()
    {
    }

    public FightTeamMemberCharacterInformations(double id, string name, uint level)
      : base(id)
    {
      this.name = name;
      this.level = level;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.name);
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteVarShort((short) this.level);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.name = reader.ReadUTF();
      this.level = (uint) reader.ReadVarUhShort();
      if (this.level < 0U)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of FightTeamMemberCharacterInformations.level.");
    }
  }
}
