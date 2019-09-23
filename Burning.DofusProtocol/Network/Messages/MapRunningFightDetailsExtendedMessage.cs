using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
  {
    public List<NamedPartyTeam> namedPartyTeams = new List<NamedPartyTeam>();
    public new const uint Id = 6500;

    public override uint MessageId
    {
      get
      {
        return 6500;
      }
    }

    public MapRunningFightDetailsExtendedMessage()
    {
    }

    public MapRunningFightDetailsExtendedMessage(
      uint fightId,
      List<GameFightFighterLightInformations> attackers,
      List<GameFightFighterLightInformations> defenders,
      List<NamedPartyTeam> namedPartyTeams)
      : base(fightId, attackers, defenders)
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
