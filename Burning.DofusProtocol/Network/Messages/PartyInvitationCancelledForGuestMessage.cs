using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
  {
    public new const uint Id = 6256;
    public double cancelerId;

    public override uint MessageId
    {
      get
      {
        return 6256;
      }
    }

    public PartyInvitationCancelledForGuestMessage()
    {
    }

    public PartyInvitationCancelledForGuestMessage(uint partyId, double cancelerId)
      : base(partyId)
    {
      this.cancelerId = cancelerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.cancelerId < 0.0 || this.cancelerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancelerId + ") on element cancelerId.");
      writer.WriteVarLong((long) this.cancelerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.cancelerId = (double) reader.ReadVarUhLong();
      if (this.cancelerId < 0.0 || this.cancelerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancelerId + ") on element of PartyInvitationCancelledForGuestMessage.cancelerId.");
    }
  }
}
