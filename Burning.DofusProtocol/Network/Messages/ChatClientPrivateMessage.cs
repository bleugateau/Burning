using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatClientPrivateMessage : ChatAbstractClientMessage
  {
    public new const uint Id = 851;
    public string receiver;

    public override uint MessageId
    {
      get
      {
        return 851;
      }
    }

    public ChatClientPrivateMessage()
    {
    }

    public ChatClientPrivateMessage(string content, string receiver)
      : base(content)
    {
      this.receiver = receiver;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.receiver);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.receiver = reader.ReadUTF();
    }
  }
}
