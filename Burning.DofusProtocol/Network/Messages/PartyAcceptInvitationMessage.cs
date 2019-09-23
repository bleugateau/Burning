using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyAcceptInvitationMessage : AbstractPartyMessage
  {
    public new const uint Id = 5580;

    public override uint MessageId
    {
      get
      {
        return 5580;
      }
    }

    public PartyAcceptInvitationMessage()
    {
    }

    public PartyAcceptInvitationMessage(uint partyId)
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
