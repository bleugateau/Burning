using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatCommunityChannelCommunityMessage : NetworkMessage
  {
    public const uint Id = 6730;
    public int communityId;

    public override uint MessageId
    {
      get
      {
        return 6730;
      }
    }

    public ChatCommunityChannelCommunityMessage()
    {
    }

    public ChatCommunityChannelCommunityMessage(int communityId)
    {
      this.communityId = communityId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.communityId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.communityId = (int) reader.ReadShort();
    }
  }
}
