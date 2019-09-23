using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AdminCommandMessage : NetworkMessage
  {
    public const uint Id = 76;
    public string content;

    public override uint MessageId
    {
      get
      {
        return 76;
      }
    }

    public AdminCommandMessage()
    {
    }

    public AdminCommandMessage(string content)
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
