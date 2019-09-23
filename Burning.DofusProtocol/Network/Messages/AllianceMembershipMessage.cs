using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceMembershipMessage : AllianceJoinedMessage
  {
    public new const uint Id = 6390;

    public override uint MessageId
    {
      get
      {
        return 6390;
      }
    }

    public AllianceMembershipMessage()
    {
    }

    public AllianceMembershipMessage(
      AllianceInformations allianceInfo,
      bool enabled,
      uint leadingGuildId)
      : base(allianceInfo, enabled, leadingGuildId)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
