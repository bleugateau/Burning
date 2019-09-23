using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 6251;
    public double cancelerId;
    public double guestId;

    public override uint MessageId
    {
      get
      {
        return 6251;
      }
    }

    public PartyCancelInvitationNotificationMessage()
    {
    }

    public PartyCancelInvitationNotificationMessage(
      uint partyId,
      double cancelerId,
      double guestId)
      : base(partyId)
    {
      this.cancelerId = cancelerId;
      this.guestId = guestId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.cancelerId < 0.0 || this.cancelerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancelerId + ") on element cancelerId.");
      writer.WriteVarLong((long) this.cancelerId);
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element guestId.");
      writer.WriteVarLong((long) this.guestId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.cancelerId = (double) reader.ReadVarUhLong();
      if (this.cancelerId < 0.0 || this.cancelerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.cancelerId + ") on element of PartyCancelInvitationNotificationMessage.cancelerId.");
      this.guestId = (double) reader.ReadVarUhLong();
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element of PartyCancelInvitationNotificationMessage.guestId.");
    }
  }
}
