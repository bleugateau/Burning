using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class AlliancePrismInformation : PrismInformation
  {
    public new const uint Id = 427;
    public AllianceInformations alliance;

    public override uint TypeId
    {
      get
      {
        return 427;
      }
    }

    public AlliancePrismInformation()
    {
    }

    public AlliancePrismInformation(
      uint typeId,
      uint state,
      uint nextVulnerabilityDate,
      uint placementDate,
      uint rewardTokenCount,
      AllianceInformations alliance)
      : base(typeId, state, nextVulnerabilityDate, placementDate, rewardTokenCount)
    {
      this.alliance = alliance;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      this.alliance.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.alliance = new AllianceInformations();
      this.alliance.Deserialize(reader);
    }
  }
}
