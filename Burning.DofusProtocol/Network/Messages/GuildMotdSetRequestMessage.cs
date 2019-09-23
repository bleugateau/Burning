using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildMotdSetRequestMessage : SocialNoticeSetRequestMessage
  {
    public new const uint Id = 6588;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 6588;
      }
    }

    public GuildMotdSetRequestMessage()
    {
    }

    public GuildMotdSetRequestMessage(string content)
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
