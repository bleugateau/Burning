using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachGameFightEndMessage : GameFightEndMessage
  {
    public new const uint Id = 6809;
    public int budget;

    public override uint MessageId
    {
      get
      {
        return 6809;
      }
    }

    public BreachGameFightEndMessage()
    {
    }

    public BreachGameFightEndMessage(
      uint duration,
      int rewardRate,
      int lootShareLimitMalus,
      List<FightResultListEntry> results,
      List<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes,
      int budget)
      : base(duration, rewardRate, lootShareLimitMalus, results, namedPartyTeamsOutcomes)
    {
      this.budget = budget;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.budget);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.budget = reader.ReadInt();
    }
  }
}
