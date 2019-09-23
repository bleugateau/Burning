using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LocalizedChatSmileyMessage : ChatSmileyMessage
  {
    public new const uint Id = 6185;
    public uint cellId;

    public override uint MessageId
    {
      get
      {
        return 6185;
      }
    }

    public LocalizedChatSmileyMessage()
    {
    }

    public LocalizedChatSmileyMessage(double entityId, uint smileyId, uint accountId, uint cellId)
      : base(entityId, smileyId, accountId)
    {
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteVarShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.cellId = (uint) reader.ReadVarUhShort();
      if (this.cellId < 0U || this.cellId > 559U)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of LocalizedChatSmileyMessage.cellId.");
    }
  }
}
