using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NpcDialogReplyMessage : NetworkMessage
  {
    public const uint Id = 5616;
    public uint replyId;

    public override uint MessageId
    {
      get
      {
        return 5616;
      }
    }

    public NpcDialogReplyMessage()
    {
    }

    public NpcDialogReplyMessage(uint replyId)
    {
      this.replyId = replyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.replyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.replyId + ") on element replyId.");
      writer.WriteVarInt((int) this.replyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.replyId = reader.ReadVarUhInt();
      if (this.replyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.replyId + ") on element of NpcDialogReplyMessage.replyId.");
    }
  }
}
