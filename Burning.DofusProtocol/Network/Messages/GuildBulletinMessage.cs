using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildBulletinMessage : BulletinMessage
  {
    public new const uint Id = 6689;

    public override uint MessageId
    {
      get
      {
        return 6689;
      }
    }

    public GuildBulletinMessage()
    {
    }

    public GuildBulletinMessage(
      string content,
      uint timestamp,
      double memberId,
      string memberName,
      uint lastNotifiedTimestamp)
      : base(content, timestamp, memberId, memberName, lastNotifiedTimestamp)
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
