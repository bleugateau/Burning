using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ContactLookErrorMessage : NetworkMessage
  {
    public const uint Id = 6045;
    public uint requestId;

    public override uint MessageId
    {
      get
      {
        return 6045;
      }
    }

    public ContactLookErrorMessage()
    {
    }

    public ContactLookErrorMessage(uint requestId)
    {
      this.requestId = requestId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element requestId.");
      writer.WriteVarInt((int) this.requestId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requestId = reader.ReadVarUhInt();
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element of ContactLookErrorMessage.requestId.");
    }
  }
}
