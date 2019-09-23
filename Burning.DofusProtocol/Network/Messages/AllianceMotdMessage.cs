using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceMotdMessage : SocialNoticeMessage
  {
    public new const uint Id = 6685;

    public override uint MessageId
    {
      get
      {
        return 6685;
      }
    }

    public AllianceMotdMessage()
    {
    }

    public AllianceMotdMessage(string content, uint timestamp, double memberId, string memberName)
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
