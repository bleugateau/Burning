using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamInformations : AbstractFightTeamInformations
  {
    public List<FightTeamMemberInformations> teamMembers = new List<FightTeamMemberInformations>();
    public new const uint Id = 33;

    public override uint TypeId
    {
      get
      {
        return 33;
      }
    }

    public FightTeamInformations()
    {
    }

    public FightTeamInformations(
      uint teamId,
      double leaderId,
      int teamSide,
      uint teamTypeId,
      uint nbWaves,
      List<FightTeamMemberInformations> teamMembers)
      : base(teamId, leaderId, teamSide, teamTypeId, nbWaves)
    {
      this.teamMembers = teamMembers;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.teamMembers.Count);
      for (int index = 0; index < this.teamMembers.Count; ++index)
      {
        writer.WriteShort((short) this.teamMembers[index].TypeId);
        this.teamMembers[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        FightTeamMemberInformations instance = ProtocolTypeManager.GetInstance<FightTeamMemberInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.teamMembers.Add(instance);
      }
    }
  }
}
