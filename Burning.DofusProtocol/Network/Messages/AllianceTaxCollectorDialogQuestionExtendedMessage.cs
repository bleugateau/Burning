using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
  {
    public new const uint Id = 6445;
    public BasicNamedAllianceInformations alliance;

    public override uint MessageId
    {
      get
      {
        return 6445;
      }
    }

    public AllianceTaxCollectorDialogQuestionExtendedMessage()
    {
    }

    public AllianceTaxCollectorDialogQuestionExtendedMessage(
      BasicGuildInformations guildInfo,
      uint maxPods,
      uint prospecting,
      uint wisdom,
      uint taxCollectorsCount,
      int taxCollectorAttack,
      double kamas,
      double experience,
      uint pods,
      double itemsValue,
      BasicNamedAllianceInformations alliance)
      : base(guildInfo, maxPods, prospecting, wisdom, taxCollectorsCount, taxCollectorAttack, kamas, experience, pods, itemsValue)
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
      this.alliance = new BasicNamedAllianceInformations();
      this.alliance.Deserialize(reader);
    }
  }
}
