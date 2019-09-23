using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EmotePlayRequestMessage : NetworkMessage
  {
    public const uint Id = 5685;
    public uint emoteId;

    public override uint MessageId
    {
      get
      {
        return 5685;
      }
    }

    public EmotePlayRequestMessage()
    {
    }

    public EmotePlayRequestMessage(uint emoteId)
    {
      this.emoteId = emoteId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element emoteId.");
      writer.WriteByte((byte) this.emoteId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.emoteId = (uint) reader.ReadByte();
      if (this.emoteId < 0U || this.emoteId > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.emoteId + ") on element of EmotePlayRequestMessage.emoteId.");
    }
  }
}
