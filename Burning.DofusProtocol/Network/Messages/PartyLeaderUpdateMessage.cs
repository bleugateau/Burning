using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 5578;
    public double partyLeaderId;

    public override uint MessageId
    {
      get
      {
        return 5578;
      }
    }

    public PartyLeaderUpdateMessage()
    {
    }

    public PartyLeaderUpdateMessage(uint partyId, double partyLeaderId)
      : base(partyId)
    {
      this.partyLeaderId = partyLeaderId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.partyLeaderId < 0.0 || this.partyLeaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.partyLeaderId + ") on element partyLeaderId.");
      writer.WriteVarLong((long) this.partyLeaderId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.partyLeaderId = (double) reader.ReadVarUhLong();
      if (this.partyLeaderId < 0.0 || this.partyLeaderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.partyLeaderId + ") on element of PartyLeaderUpdateMessage.partyLeaderId.");
    }
  }
}
