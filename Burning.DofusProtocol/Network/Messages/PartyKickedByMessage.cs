using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyKickedByMessage : AbstractPartyMessage
  {
    public new const uint Id = 5590;
    public double kickerId;

    public override uint MessageId
    {
      get
      {
        return 5590;
      }
    }

    public PartyKickedByMessage()
    {
    }

    public PartyKickedByMessage(uint partyId, double kickerId)
      : base(partyId)
    {
      this.kickerId = kickerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.kickerId < 0.0 || this.kickerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kickerId + ") on element kickerId.");
      writer.WriteVarLong((long) this.kickerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.kickerId = (double) reader.ReadVarUhLong();
      if (this.kickerId < 0.0 || this.kickerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.kickerId + ") on element of PartyKickedByMessage.kickerId.");
    }
  }
}
