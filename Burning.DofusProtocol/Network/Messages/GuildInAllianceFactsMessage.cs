using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInAllianceFactsMessage : GuildFactsMessage
  {
    public new const uint Id = 6422;
    public BasicNamedAllianceInformations allianceInfos;

    public override uint MessageId
    {
      get
      {
        return 6422;
      }
    }

    public GuildInAllianceFactsMessage()
    {
    }

    public GuildInAllianceFactsMessage(
      GuildFactSheetInformations infos,
      uint creationDate,
      uint nbTaxCollectors,
      List<CharacterMinimalGuildPublicInformations> members,
      BasicNamedAllianceInformations allianceInfos)
      : base(infos, creationDate, nbTaxCollectors, members)
    {
      this.allianceInfos = allianceInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.allianceInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceInfos = new BasicNamedAllianceInformations();
      this.allianceInfos.Deserialize(reader);
    }
  }
}
