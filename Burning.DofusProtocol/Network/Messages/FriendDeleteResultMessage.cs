using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendDeleteResultMessage : NetworkMessage
  {
    public const uint Id = 5601;
    public bool success;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 5601;
      }
    }

    public FriendDeleteResultMessage()
    {
    }

    public FriendDeleteResultMessage(bool success, string name)
    {
      this.success = success;
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.success);
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.success = reader.ReadBoolean();
      this.name = reader.ReadUTF();
    }
  }
}
