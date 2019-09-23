using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolPartyLostMessage : NetworkMessage
  {
    public const uint Id = 6580;
    public uint idolId;

    public override uint MessageId
    {
      get
      {
        return 6580;
      }
    }

    public IdolPartyLostMessage()
    {
    }

    public IdolPartyLostMessage(uint idolId)
    {
      this.idolId = idolId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.idolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.idolId + ") on element idolId.");
      writer.WriteVarShort((short) this.idolId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.idolId = (uint) reader.ReadVarUhShort();
      if (this.idolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.idolId + ") on element of IdolPartyLostMessage.idolId.");
    }
  }
}
