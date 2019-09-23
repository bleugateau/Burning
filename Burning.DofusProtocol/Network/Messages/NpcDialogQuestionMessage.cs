using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NpcDialogQuestionMessage : NetworkMessage
  {
    public List<string> dialogParams = new List<string>();
    public List<uint> visibleReplies = new List<uint>();
    public const uint Id = 5617;
    public uint messageId;

    public override uint MessageId
    {
      get
      {
        return 5617;
      }
    }

    public NpcDialogQuestionMessage()
    {
    }

    public NpcDialogQuestionMessage(
      uint messageId,
      List<string> dialogParams,
      List<uint> visibleReplies)
    {
      this.messageId = messageId;
      this.dialogParams = dialogParams;
      this.visibleReplies = visibleReplies;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.messageId < 0U)
        throw new Exception("Forbidden value (" + (object) this.messageId + ") on element messageId.");
      writer.WriteVarInt((int) this.messageId);
      writer.WriteShort((short) this.dialogParams.Count);
      for (int index = 0; index < this.dialogParams.Count; ++index)
        writer.WriteUTF(this.dialogParams[index]);
      writer.WriteShort((short) this.visibleReplies.Count);
      for (int index = 0; index < this.visibleReplies.Count; ++index)
      {
        if (this.visibleReplies[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.visibleReplies[index] + ") on element 3 (starting at 1) of visibleReplies.");
        writer.WriteVarInt((int) this.visibleReplies[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.messageId = reader.ReadVarUhInt();
      if (this.messageId < 0U)
        throw new Exception("Forbidden value (" + (object) this.messageId + ") on element of NpcDialogQuestionMessage.messageId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
        this.dialogParams.Add(reader.ReadUTF());
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        uint num3 = reader.ReadVarUhInt();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of visibleReplies.");
        this.visibleReplies.Add(num3);
      }
    }
  }
}
