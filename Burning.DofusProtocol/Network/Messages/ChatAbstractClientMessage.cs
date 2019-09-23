using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatAbstractClientMessage : NetworkMessage
  {
    public const uint Id = 850;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 850;
      }
    }

    public ChatAbstractClientMessage()
    {
    }

    public ChatAbstractClientMessage(string content)
    {
      this.content = content;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.content);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.content = reader.ReadUTF();
    }
  }
}
