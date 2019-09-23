using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceMotdSetErrorMessage : SocialNoticeSetErrorMessage
  {
    public new const uint Id = 6683;

    public override uint MessageId
    {
      get
      {
        return 6683;
      }
    }

    public AllianceMotdSetErrorMessage()
    {
    }

    public AllianceMotdSetErrorMessage(uint reason)
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
