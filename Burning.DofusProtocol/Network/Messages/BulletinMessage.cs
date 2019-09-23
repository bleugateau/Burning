using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BulletinMessage : SocialNoticeMessage
  {
    public new const uint Id = 6695;
    public uint lastNotifiedTimestamp;

    public override uint MessageId
    {
      get
      {
        return 6695;
      }
    }

    public BulletinMessage()
    {
    }

    public BulletinMessage(
      string content,
      uint timestamp,
      double memberId,
      string memberName,
      uint lastNotifiedTimestamp)
      : base(content, timestamp, memberId, memberName)
    {
      this.lastNotifiedTimestamp = lastNotifiedTimestamp;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.lastNotifiedTimestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNotifiedTimestamp + ") on element lastNotifiedTimestamp.");
      writer.WriteInt((int) this.lastNotifiedTimestamp);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.lastNotifiedTimestamp = (uint) reader.ReadInt();
      if (this.lastNotifiedTimestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.lastNotifiedTimestamp + ") on element of BulletinMessage.lastNotifiedTimestamp.");
    }
  }
}
