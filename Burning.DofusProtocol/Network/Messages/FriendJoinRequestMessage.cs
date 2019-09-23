using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendJoinRequestMessage : NetworkMessage
  {
    public const uint Id = 5605;
    public string name;

    public override uint MessageId
    {
      get
      {
        return 5605;
      }
    }

    public FriendJoinRequestMessage()
    {
    }

    public FriendJoinRequestMessage(string name)
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
