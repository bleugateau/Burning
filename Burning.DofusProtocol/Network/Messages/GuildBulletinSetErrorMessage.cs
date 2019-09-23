using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildBulletinSetErrorMessage : SocialNoticeSetErrorMessage
  {
    public new const uint Id = 6691;

    public override uint MessageId
    {
      get
      {
        return 6691;
      }
    }

    public GuildBulletinSetErrorMessage()
    {
    }

    public GuildBulletinSetErrorMessage(uint reason)
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
