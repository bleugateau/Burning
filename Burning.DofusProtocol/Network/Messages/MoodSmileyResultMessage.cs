using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MoodSmileyResultMessage : NetworkMessage
  {
    public const uint Id = 6196;
    public uint resultCode;
    public uint smileyId;

    public override uint MessageId
    {
      get
      {
        return 6196;
      }
    }

    public MoodSmileyResultMessage()
    {
    }

    public MoodSmileyResultMessage(uint resultCode, uint smileyId)
    {
      this.resultCode = resultCode;
      this.smileyId = smileyId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.resultCode);
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element smileyId.");
      writer.WriteVarShort((short) this.smileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.resultCode = (uint) reader.ReadByte();
      if (this.resultCode < 0U)
        throw new Exception("Forbidden value (" + (object) this.resultCode + ") on element of MoodSmileyResultMessage.resultCode.");
      this.smileyId = (uint) reader.ReadVarUhShort();
      if (this.smileyId < 0U)
        throw new Exception("Forbidden value (" + (object) this.smileyId + ") on element of MoodSmileyResultMessage.smileyId.");
    }
  }
}
