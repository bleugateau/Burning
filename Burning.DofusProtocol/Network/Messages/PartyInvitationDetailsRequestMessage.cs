using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 6264;

    public override uint MessageId
    {
      get
      {
        return 6264;
      }
    }

    public PartyInvitationDetailsRequestMessage()
    {
    }

    public PartyInvitationDetailsRequestMessage(uint partyId)
      : base(partyId)
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
