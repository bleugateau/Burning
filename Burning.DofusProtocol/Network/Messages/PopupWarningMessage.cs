using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PopupWarningMessage : NetworkMessage
  {
    public const uint Id = 6134;
    public uint lockDuration;
    public string author;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 6134;
      }
    }

    public PopupWarningMessage()
    {
    }

    public PopupWarningMessage(uint lockDuration, string author, string content)
    {
      this.lockDuration = lockDuration;
      this.author = author;
      this.content = content;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.lockDuration < 0U || this.lockDuration > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.lockDuration + ") on element lockDuration.");
      writer.WriteByte((byte) this.lockDuration);
      writer.WriteUTF(this.author);
      writer.WriteUTF(this.content);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.lockDuration = (uint) reader.ReadByte();
      if (this.lockDuration < 0U || this.lockDuration > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.lockDuration + ") on element of PopupWarningMessage.lockDuration.");
      this.author = reader.ReadUTF();
      this.content = reader.ReadUTF();
    }
  }
}
