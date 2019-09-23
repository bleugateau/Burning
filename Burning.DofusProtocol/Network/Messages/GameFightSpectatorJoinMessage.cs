using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightSpectatorJoinMessage : GameFightJoinMessage
  {
    public List<NamedPartyTeam> namedPartyTeams = new List<NamedPartyTeam>();
    public new const uint Id = 6504;

    public override uint MessageId
    {
      get
      {
        return 6504;
      }
    }

    public GameFightSpectatorJoinMessage()
    {
    }

    public GameFightSpectatorJoinMessage(
      bool isTeamPhase,
      bool canBeCancelled,
      bool canSayReady,
      bool isFightStarted,
      uint timeMaxBeforeFightStart,
      uint fightType,
      List<NamedPartyTeam> namedPartyTeams)
      : base(isTeamPhase, canBeCancelled, canSayReady, isFightStarted, timeMaxBeforeFightStart, fightType)
    {
      this.namedPartyTeams = namedPartyTeams;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.namedPartyTeams.Count);
      for (int index = 0; index < this.namedPartyTeams.Count; ++index)
        this.namedPartyTeams[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        NamedPartyTeam namedPartyTeam = new NamedPartyTeam();
        namedPartyTeam.Deserialize(reader);
        this.namedPartyTeams.Add(namedPartyTeam);
      }
    }
  }
}
