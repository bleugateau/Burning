using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendsListMessage : NetworkMessage
  {
    public List<FriendInformations> friendsList = new List<FriendInformations>();
    public const uint Id = 4002;

    public override uint MessageId
    {
      get
      {
        return 4002;
      }
    }

    public FriendsListMessage()
    {
    }

    public FriendsListMessage(List<FriendInformations> friendsList)
    {
      this.friendsList = friendsList;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.friendsList.Count);
      for (int index = 0; index < this.friendsList.Count; ++index)
      {
        writer.WriteShort((short) this.friendsList[index].TypeId);
        this.friendsList[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        FriendInformations instance = ProtocolTypeManager.GetInstance<FriendInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.friendsList.Add(instance);
      }
    }
  }
}
