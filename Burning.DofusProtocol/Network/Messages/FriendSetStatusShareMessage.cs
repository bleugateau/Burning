using FlatyBot.Common.IO;
using FlatyBot.Common.Network;

namespace Burning.DofusProtocol.Network.Messages
{
  public class FriendSetStatusShareMessage : NetworkMessage
  {
    public const uint Id = 6822;
    public bool share;

    public override uint MessageId
    {
      get
      {
        return 6822;
      }
    }

    public FriendSetStatusShareMessage()
    {
    }

    public FriendSetStatusShareMessage(bool share)
    {
      this.share = share;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.share);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.share = reader.ReadBoolean();
    }
  }
}
