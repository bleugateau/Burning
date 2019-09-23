using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class NamedPartyTeamWithOutcome
  {
    public const uint Id = 470;
    public NamedPartyTeam team;
    public uint outcome;

    public virtual uint TypeId
    {
      get
      {
        return 470;
      }
    }

    public NamedPartyTeamWithOutcome()
    {
    }

    public NamedPartyTeamWithOutcome(NamedPartyTeam team, uint outcome)
    {
      this.team = team;
      this.outcome = outcome;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      this.team.Serialize(writer);
      writer.WriteVarShort((short) this.outcome);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.team = new NamedPartyTeam();
      this.team.Deserialize(reader);
      this.outcome = (uint) reader.ReadVarUhShort();
      if (this.outcome < 0U)
        throw new Exception("Forbidden value (" + (object) this.outcome + ") on element of NamedPartyTeamWithOutcome.outcome.");
    }
  }
}
