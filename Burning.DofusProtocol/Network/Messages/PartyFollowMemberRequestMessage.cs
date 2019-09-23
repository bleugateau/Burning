using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyFollowMemberRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 5577;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5577;
      }
    }

    public PartyFollowMemberRequestMessage()
    {
    }

    public PartyFollowMemberRequestMessage(uint partyId, double playerId)
      : base(partyId)
    {
      this.playerId = playerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of PartyFollowMemberRequestMessage.playerId.");
    }
  }
}
