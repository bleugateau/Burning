using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendAddRequestMessage : NetworkMessage
  {
    public const uint Id = 4004;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 4004;
      }
    }

    public FriendAddRequestMessage()
    {
    }

    public FriendAddRequestMessage(string name)
    {
      this.name = name;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.name);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.name = reader.ReadUTF();
    }
  }
}
