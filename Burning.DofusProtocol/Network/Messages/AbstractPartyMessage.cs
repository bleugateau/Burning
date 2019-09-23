using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractPartyMessage : NetworkMessage
  {
    public const uint Id = 6274;
    public uint partyId;

    public override uint MessageId
    {
      get
      {
        return 6274;
      }
    }

    public AbstractPartyMessage()
    {
    }

    public AbstractPartyMessage(uint partyId)
    {
      this.partyId = partyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.partyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.partyId + ") on element partyId.");
      writer.WriteVarInt((int) this.partyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.partyId = reader.ReadVarUhInt();
      if (this.partyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.partyId + ") on element of AbstractPartyMessage.partyId.");
    }
  }
}
