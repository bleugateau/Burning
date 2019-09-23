using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyCannotJoinErrorMessage : AbstractPartyMessage
  {
    public new const uint Id = 5583;
    public uint reason;

    public override uint MessageId
    {
      get
      {
        return 5583;
      }
    }

    public PartyCannotJoinErrorMessage()
    {
    }

    public PartyCannotJoinErrorMessage(uint partyId, uint reason)
      : base(partyId)
    {
      this.reason = reason;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.reason);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.reason = (uint) reader.ReadByte();
      if (this.reason < 0U)
        throw new Exception("Forbidden value (" + (object) this.reason + ") on element of PartyCannotJoinErrorMessage.reason.");
    }
  }
}
