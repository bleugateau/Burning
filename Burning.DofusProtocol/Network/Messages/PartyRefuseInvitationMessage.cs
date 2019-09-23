using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyRefuseInvitationMessage : AbstractPartyMessage
  {
    public new const uint Id = 5582;

    public override uint MessageId
    {
      get
      {
        return 5582;
      }
    }

    public PartyRefuseInvitationMessage()
    {
    }

    public PartyRefuseInvitationMessage(uint partyId)
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
