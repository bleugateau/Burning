using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceBulletinSetErrorMessage : SocialNoticeSetErrorMessage
  {
    public new const uint Id = 6692;

    public override uint MessageId
    {
      get
      {
        return 6692;
      }
    }

    public AllianceBulletinSetErrorMessage()
    {
    }

    public AllianceBulletinSetErrorMessage(uint reason)
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
