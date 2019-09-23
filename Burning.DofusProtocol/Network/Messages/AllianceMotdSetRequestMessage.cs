using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
  {
    public new const uint Id = 6687;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 6687;
      }
    }

    public AllianceMotdSetRequestMessage()
    {
    }

    public AllianceMotdSetRequestMessage(string content)
    {
      this.content = content;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.content);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.content = reader.ReadUTF();
    }
  }
}
