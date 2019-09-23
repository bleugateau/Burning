using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatServerMessage : ChatAbstractServerMessage
  {
    public new const uint Id = 881;
    public double senderId;
    public string senderName;
    public string prefix;
    public uint senderAccountId;

    public override uint MessageId
    {
      get
      {
        return 881;
      }
    }

    public ChatServerMessage()
    {
    }

    public ChatServerMessage(
      uint channel,
      string content,
      uint timestamp,
      string fingerprint,
      double senderId,
      string senderName,
      string prefix,
      uint senderAccountId)
      : base(channel, content, timestamp, fingerprint)
    {
      this.senderId = senderId;
      this.senderName = senderName;
      this.prefix = prefix;
      this.senderAccountId = senderAccountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.senderId < -9.00719925474099E+15 || this.senderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.senderId + ") on element senderId.");
      writer.WriteDouble(this.senderId);
      writer.WriteUTF(this.senderName);
      writer.WriteUTF(this.prefix);
      if (this.senderAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.senderAccountId + ") on element senderAccountId.");
      writer.WriteInt((int) this.senderAccountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.senderId = reader.ReadDouble();
      if (this.senderId < -9.00719925474099E+15 || this.senderId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.senderId + ") on element of ChatServerMessage.senderId.");
      this.senderName = reader.ReadUTF();
      this.prefix = reader.ReadUTF();
      this.senderAccountId = (uint) reader.ReadInt();
      if (this.senderAccountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.senderAccountId + ") on element of ChatServerMessage.senderAccountId.");
    }
  }
}
