using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyMemberRemoveMessage : AbstractPartyEventMessage
  {
    public new const uint Id = 5579;
    public double leavingPlayerId;

    public override uint MessageId
    {
      get
      {
        return 5579;
      }
    }

    public PartyMemberRemoveMessage()
    {
    }

    public PartyMemberRemoveMessage(uint partyId, double leavingPlayerId)
      : base(partyId)
    {
      this.leavingPlayerId = leavingPlayerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.leavingPlayerId < 0.0 || this.leavingPlayerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leavingPlayerId + ") on element leavingPlayerId.");
      writer.WriteVarLong((long) this.leavingPlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.leavingPlayerId = (double) reader.ReadVarUhLong();
      if (this.leavingPlayerId < 0.0 || this.leavingPlayerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leavingPlayerId + ") on element of PartyMemberRemoveMessage.leavingPlayerId.");
    }
  }
}
