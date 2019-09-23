using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ContactLookRequestByIdMessage : ContactLookRequestMessage
  {
    public new const uint Id = 5935;
    public double playerId;

    public override uint MessageId
    {
      get
      {
        return 5935;
      }
    }

    public ContactLookRequestByIdMessage()
    {
    }

    public ContactLookRequestByIdMessage(uint requestId, uint contactType, double playerId)
      : base(requestId, contactType)
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
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of ContactLookRequestByIdMessage.playerId.");
    }
  }
}
