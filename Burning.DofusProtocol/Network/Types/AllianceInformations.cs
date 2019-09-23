using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class AllianceInformations : BasicNamedAllianceInformations
  {
    public new const uint Id = 417;
    public GuildEmblem allianceEmblem;

    public override uint TypeId
    {
      get
      {
        return 417;
      }
    }

    public AllianceInformations()
    {
    }

    public AllianceInformations(
      uint allianceId,
      string allianceTag,
      string allianceName,
      GuildEmblem allianceEmblem)
      : base(allianceId, allianceTag, allianceName)
    {
      this.allianceEmblem = allianceEmblem;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.allianceEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.allianceEmblem = new GuildEmblem();
      this.allianceEmblem.Deserialize(reader);
    }
  }
}
