using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatAbstractServerMessage : NetworkMessage
  {
    public const uint Id = 880;
    public uint channel;
    public string content;
    public uint timestamp;
    public string fingerprint;

    public override uint MessageId
    {
      get
      {
        return 880;
      }
    }

    public ChatAbstractServerMessage()
    {
    }

    public ChatAbstractServerMessage(
      uint channel,
      string content,
      uint timestamp,
      string fingerprint)
    {
      this.channel = channel;
      this.content = content;
      this.timestamp = timestamp;
      this.fingerprint = fingerprint;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.channel);
      writer.WriteUTF(this.content);
      if (this.timestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element timestamp.");
      writer.WriteInt((int) this.timestamp);
      writer.WriteUTF(this.fingerprint);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.channel = (uint) reader.ReadByte();
      if (this.channel < 0U)
        throw new Exception("Forbidden value (" + (object) this.channel + ") on element of ChatAbstractServerMessage.channel.");
      this.content = reader.ReadUTF();
      this.timestamp = (uint) reader.ReadInt();
      if (this.timestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element of ChatAbstractServerMessage.timestamp.");
      this.fingerprint = reader.ReadUTF();
    }
  }
}
