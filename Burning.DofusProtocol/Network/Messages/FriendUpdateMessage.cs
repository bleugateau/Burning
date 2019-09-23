using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendUpdateMessage : NetworkMessage
  {
    public const uint Id = 5924;
    public FriendInformations friendUpdated;

    public override uint MessageId
    {
      get
      {
        return 5924;
      }
    }

    public FriendUpdateMessage()
    {
    }

    public FriendUpdateMessage(FriendInformations friendUpdated)
    {
      this.friendUpdated = friendUpdated;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.friendUpdated.TypeId);
      this.friendUpdated.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.friendUpdated = ProtocolTypeManager.GetInstance<FriendInformations>((uint) reader.ReadUShort());
      this.friendUpdated.Deserialize(reader);
    }
  }
}
