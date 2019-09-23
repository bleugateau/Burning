using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
  {
    public new const uint Id = 426;
    public BasicAllianceInformations allianceInfos;

    public override uint TypeId
    {
      get
      {
        return 426;
      }
    }

    public FightTeamMemberWithAllianceCharacterInformations()
    {
    }

    public FightTeamMemberWithAllianceCharacterInformations(
      double id,
      string name,
      uint level,
      BasicAllianceInformations allianceInfos)
      : base(id, name, level)
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
      this.allianceInfos = new BasicAllianceInformations();
      this.allianceInfos.Deserialize(reader);
    }
  }
}
