using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ClientKeyMessage : NetworkMessage
  {
    public const uint Id = 5607;
    public string key;

    public override uint MessageId
    {
      get
      {
        return 5607;
      }
    }

    public ClientKeyMessage()
    {
    }

    public ClientKeyMessage(string key)
    {
      this.key = key;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.key);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.key = reader.ReadUTF();
    }
  }
}
