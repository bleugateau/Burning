using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyCancelInvitationMessage : AbstractPartyMessage
  {
    public new const uint Id = 6254;
    public double guestId;

    public override uint MessageId
    {
      get
      {
        return 6254;
      }
    }

    public PartyCancelInvitationMessage()
    {
    }

    public PartyCancelInvitationMessage(uint partyId, double guestId)
      : base(partyId)
    {
      this.guestId = guestId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element guestId.");
      writer.WriteVarLong((long) this.guestId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.guestId = (double) reader.ReadVarUhLong();
      if (this.guestId < 0.0 || this.guestId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.guestId + ") on element of PartyCancelInvitationMessage.guestId.");
    }
  }
}
