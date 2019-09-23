using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SocialNoticeMessage : NetworkMessage
  {
    public const uint Id = 6688;
    public string content;
    public uint timestamp;
    public double memberId;
    public string memberName;

    public override uint MessageId
    {
      get
      {
        return 6688;
      }
    }

    public SocialNoticeMessage()
    {
    }

    public SocialNoticeMessage(string content, uint timestamp, double memberId, string memberName)
    {
      this.content = content;
      this.timestamp = timestamp;
      this.memberId = memberId;
      this.memberName = memberName;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.content);
      if (this.timestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element timestamp.");
      writer.WriteInt((int) this.timestamp);
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      writer.WriteUTF(this.memberName);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.content = reader.ReadUTF();
      this.timestamp = (uint) reader.ReadInt();
      if (this.timestamp < 0U)
        throw new Exception("Forbidden value (" + (object) this.timestamp + ") on element of SocialNoticeMessage.timestamp.");
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of SocialNoticeMessage.memberId.");
      this.memberName = reader.ReadUTF();
    }
  }
}
