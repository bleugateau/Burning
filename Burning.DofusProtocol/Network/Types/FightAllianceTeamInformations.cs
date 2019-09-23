using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightAllianceTeamInformations : FightTeamInformations
  {
    public new const uint Id = 439;
    public uint relation;

    public override uint TypeId
    {
      get
      {
        return 439;
      }
    }

    public FightAllianceTeamInformations()
    {
    }

    public FightAllianceTeamInformations(
      uint teamId,
      double leaderId,
      int teamSide,
      uint teamTypeId,
      uint nbWaves,
      List<FightTeamMemberInformations> teamMembers,
      uint relation)
      : base(teamId, leaderId, teamSide, teamTypeId, nbWaves, teamMembers)
    {
      this.relation = relation;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.relation);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.relation = (uint) reader.ReadByte();
      if (this.relation < 0U)
        throw new Exception("Forbidden value (" + (object) this.relation + ") on element of FightAllianceTeamInformations.relation.");
    }
  }
}
