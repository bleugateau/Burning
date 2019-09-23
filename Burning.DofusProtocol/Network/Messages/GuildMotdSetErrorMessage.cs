using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
  {
    public new const uint Id = 6591;

    public override uint MessageId
    {
      get
      {
        return 6591;
      }
    }

    public GuildMotdSetErrorMessage()
    {
    }

    public GuildMotdSetErrorMessage(uint reason)
      : base(reason)
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
