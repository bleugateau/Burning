using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatSmileyRequestMessage : NetworkMessage
  {
    public const uint Id = 800;
    public uint smileyId;

    public override uint MessageId
    {
      get
      {
        return 800;
      }
    }

    public ChatSmileyRequestMessage()
    {
    }

    public ChatSmileyRequestMessage(uint smileyId)
    {
      this.smileyId = smileyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element smileyId.");
      writer.WriteVarShort((short) this.smileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.smileyId = (uint) reader.ReadVarUhShort();
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element of ChatSmileyRequestMessage.smileyId.");
    }
  }
}
