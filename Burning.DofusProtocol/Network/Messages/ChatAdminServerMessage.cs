using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatAdminServerMessage : ChatServerMessage
  {
    public new const uint Id = 6135;

    public override uint MessageId
    {
      get
      {
        return 6135;
      }
    }

    public ChatAdminServerMessage()
    {
    }

    public ChatAdminServerMessage(
      uint channel,
      string content,
      uint timestamp,
      string fingerprint,
      double senderId,
      string senderName,
      string prefix,
      uint senderAccountId)
      : base(channel, content, timestamp, fingerprint, senderId, senderName, prefix, senderAccountId)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
