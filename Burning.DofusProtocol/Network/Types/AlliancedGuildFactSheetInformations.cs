using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class AlliancedGuildFactSheetInformations : GuildInformations
  {
    public new const uint Id = 422;
    public BasicNamedAllianceInformations allianceInfos;

    public override uint TypeId
    {
      get
      {
        return 422;
      }
    }

    public AlliancedGuildFactSheetInformations()
    {
    }

    public AlliancedGuildFactSheetInformations(
      uint guildId,
      string guildName,
      uint guildLevel,
      GuildEmblem guildEmblem,
      BasicNamedAllianceInformations allianceInfos)
      : base(guildId, guildName, guildLevel, guildEmblem)
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
