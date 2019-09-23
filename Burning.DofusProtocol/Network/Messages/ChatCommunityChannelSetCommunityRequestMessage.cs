using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ChatCommunityChannelSetCommunityRequestMessage : NetworkMessage
  {
    public const uint Id = 6729;
    public int communityId;

    public override uint MessageId
    {
      get
      {
        return 6729;
      }
    }

    public ChatCommunityChannelSetCommunityRequestMessage()
    {
    }

    public ChatCommunityChannelSetCommunityRequestMessage(int communityId)
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
