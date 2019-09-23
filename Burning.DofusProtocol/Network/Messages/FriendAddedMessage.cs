using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendAddedMessage : NetworkMessage
  {
    public const uint Id = 5599;
    public FriendInformations friendAdded;

    public override uint MessageId
    {
      get
      {
        return 5599;
      }
    }

    public FriendAddedMessage()
    {
    }

    public FriendAddedMessage(FriendInformations friendAdded)
    {
      this.friendAdded = friendAdded;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.friendAdded.TypeId);
      this.friendAdded.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.friendAdded = ProtocolTypeManager.GetInstance<FriendInformations>((uint) reader.ReadUShort());
      this.friendAdded.Deserialize(reader);
    }
  }
}
