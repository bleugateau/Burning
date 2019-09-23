using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ContactLookRequestMessage : NetworkMessage
  {
    public const uint Id = 5932;
    public uint requestId;
    public uint contactType;

    public override uint MessageId
    {
      get
      {
        return 5932;
      }
    }

    public ContactLookRequestMessage()
    {
    }

    public ContactLookRequestMessage(uint requestId, uint contactType)
    {
      this.requestId = requestId;
      this.contactType = contactType;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requestId < 0U || this.requestId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element requestId.");
      writer.WriteByte((byte) this.requestId);
      writer.WriteByte((byte) this.contactType);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requestId = (uint) reader.ReadByte();
      if (this.requestId < 0U || this.requestId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element of ContactLookRequestMessage.requestId.");
      this.contactType = (uint) reader.ReadByte();
      if (this.contactType < 0U)
        throw new Exception("Forbidden value (" + (object) this.contactType + ") on element of ContactLookRequestMessage.contactType.");
    }
  }
}
