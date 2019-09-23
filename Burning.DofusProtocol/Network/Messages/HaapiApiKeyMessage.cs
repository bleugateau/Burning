using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HaapiApiKeyMessage : NetworkMessage
  {
    public const uint Id = 6649;
    public string token;

    public override uint MessageId
    {
      get
      {
        return 6649;
      }
    }

    public HaapiApiKeyMessage()
    {
    }

    public HaapiApiKeyMessage(string token)
    {
      this.token = token;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.token);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.token = reader.ReadUTF();
    }
  }
}
