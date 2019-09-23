using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyNameSetErrorMessage : AbstractPartyMessage
  {
    public new const uint Id = 6501;
    public uint result;

    public override uint MessageId
    {
      get
      {
        return 6501;
      }
    }

    public PartyNameSetErrorMessage()
    {
    }

    public PartyNameSetErrorMessage(uint partyId, uint result)
      : base(partyId)
    {
      this.result = result;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.result);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.result = (uint) reader.ReadByte();
      if (this.result < 0U)
        throw new Exception("Forbidden value (" + (object) this.result + ") on element of PartyNameSetErrorMessage.result.");
    }
  }
}
