using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyKickRequestMessage : AbstractPartyMessage
  {
    public new const uint Id = 5592;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5592;
      }
    }

    public PartyKickRequestMessage()
    {
    }

    public PartyKickRequestMessage(uint partyId, double playerId)
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
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of PartyKickRequestMessage.playerId.");
    }
  }
}
