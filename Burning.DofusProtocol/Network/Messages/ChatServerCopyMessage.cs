using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatServerCopyMessage : ChatAbstractServerMessage
  {
    public new const uint Id = 882;
    public double receiverId;
    public string receiverName;

    public override uint MessageId
    {
      get
      {
        return 882;
      }
    }

    public ChatServerCopyMessage()
    {
    }

    public ChatServerCopyMessage(
      uint channel,
      string content,
      uint timestamp,
      string fingerprint,
      double receiverId,
      string receiverName)
      : base(channel, content, timestamp, fingerprint)
    {
      this.receiverId = receiverId;
      this.receiverName = receiverName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.receiverId < 0.0 || this.receiverId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.receiverId + ") on element receiverId.");
      writer.WriteVarLong((long) this.receiverId);
      writer.WriteUTF(this.receiverName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.receiverId = (double) reader.ReadVarUhLong();
      if (this.receiverId < 0.0 || this.receiverId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.receiverId + ") on element of ChatServerCopyMessage.receiverId.");
      this.receiverName = reader.ReadUTF();
    }
  }
}
