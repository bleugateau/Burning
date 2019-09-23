using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMotdMessage : SocialNoticeMessage
  {
    public new const uint Id = 6590;

    public override uint MessageId
    {
      get
      {
        return 6590;
      }
    }

    public GuildMotdMessage()
    {
    }

    public GuildMotdMessage(string content, uint timestamp, double memberId, string memberName)
      : base(content, timestamp, memberId, memberName)
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
